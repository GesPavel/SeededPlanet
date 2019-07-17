using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private static Dictionary<GroundStates, Sprite> SpriteMap;
    [SerializeField] private static float maxWaterValue = 25;
    private static float waterDryPerSecond;
    private bool isPlowed = false;

    [HideInInspector] private float currentWaterCount;
    private GroundStates currentState;
    public bool isOccupied { get; set; }
    public float CurrentWaterCount { get => currentWaterCount; set => currentWaterCount = value; }

    public enum GroundStates
    {
        DryRaw,
        WetRaw,
        DryPlowed,
        WetPlowed
    }

    private void Awake()
    {
        FillMap();
        EnterState(GroundStates.DryRaw);
        isOccupied = false;
        
    }
    private void Update()
    {
        Dry();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().currentGroundPosition = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>().currentGroundPosition == this)
        {
            collision.gameObject.GetComponent<PlayerController>().currentGroundPosition = null;
        }
    }
    public void AddWater(float water)
    {
        waterDryPerSecond = Time.deltaTime;
        if (currentState == GroundStates.DryPlowed)
            EnterState(GroundStates.WetPlowed);
        else if (currentState == GroundStates.DryRaw)
            EnterState(GroundStates.WetRaw);
        CurrentWaterCount += water;
        if (CurrentWaterCount > maxWaterValue)
            CurrentWaterCount = maxWaterValue;
    }
    private void Dry()
    {
        CurrentWaterCount -= waterDryPerSecond;
        if (CurrentWaterCount <= 0 )
        {
            CurrentWaterCount = 0;
            if (currentState == GroundStates.WetPlowed)
                EnterState(GroundStates.DryPlowed);
            else if (currentState == GroundStates.WetRaw)
                EnterState(GroundStates.DryRaw);
        }
    }
    public void Plow()
    {
        if (currentState == GroundStates.DryRaw)
            EnterState(GroundStates.DryPlowed);
        else if (currentState == GroundStates.WetRaw)
            EnterState(GroundStates.WetPlowed);
    }
    public void AddPlant(GameObject plant)
    {
        if (!isOccupied)
        {
            GameObject sapling = Instantiate(plant, transform.position, Quaternion.identity);
            sapling.GetComponent<Plant>().SetBaseGround(this);
            isOccupied = true;
        }
    }
    private void EnterState(GroundStates state)
    {
        currentState = state;
        Sprite sprite =  SpriteMap[state];
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    private void FillMap()
    {
        SpriteMap = new Dictionary<GroundStates, Sprite>();
        SpriteVault vault = FindObjectOfType<SpriteVault>();
        SpriteMap.Add(GroundStates.DryRaw, vault.DryRawSprite);
        SpriteMap.Add(GroundStates.WetRaw, vault.WetRawSprite);
        SpriteMap.Add(GroundStates.DryPlowed, vault.DryPlowedSprite);
        SpriteMap.Add(GroundStates.WetPlowed, vault.WetPlowedSprite);
    }
    
}


