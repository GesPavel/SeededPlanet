using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private static Dictionary<GroundStates, Sprite> SpriteMap;
    private GroundStates currentState;

    [SerializeField] private static float maxWaterValue = 25;
    private static float waterDryPerSecond;
    [HideInInspector] private float currentWaterCount;
    public bool IsWatered { get; private set; } = false;
    private float CurrentWaterCount { get => currentWaterCount; set => currentWaterCount = value; }

    private float fertilization;
    public bool IsFertilized { get; private set; }

    public bool IsPlowed { get; private set; }
    public bool isOccupiedByPlant { get; set; }


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
        IsPlowed = false;
        isOccupiedByPlant = false;

    }
    private void Update()
    {
        Dry();
        if (isOccupiedByPlant)
            TransferFertilizerToPlant();
    }

    private void TransferFertilizerToPlant()
    {
        if (fertilization <= 0)
        {
            fertilization = 0;
            IsFertilized = false;
        }
        else
            fertilization--;

    }

    public void AddFertilizer(float fertilizerAmount)
    {
        fertilization += fertilizerAmount;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().SetCurrentGroundPosition(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null && collision.gameObject.GetComponent<PlayerController>().GetCurrentGroundPosition() == this)
        {
            collision.gameObject.GetComponent<PlayerController>().SetCurrentGroundPosition(null);
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
        IsWatered = true;
        if (CurrentWaterCount > maxWaterValue)
            CurrentWaterCount = maxWaterValue;
    }
    private void Dry()
    {
        CurrentWaterCount -= waterDryPerSecond;
        if (CurrentWaterCount <= 0)
        {
            CurrentWaterCount = 0;
            IsWatered = false;
            if (currentState == GroundStates.WetPlowed)
                EnterState(GroundStates.DryPlowed);
            else if (currentState == GroundStates.WetRaw)
                EnterState(GroundStates.DryRaw);
        }
    }
    public void Plow()
    {
        IsPlowed = true;
        if (currentState == GroundStates.DryRaw)
            EnterState(GroundStates.DryPlowed);
        else if (currentState == GroundStates.WetRaw)
            EnterState(GroundStates.WetPlowed);
    }
    public void AddPlant(GameObject plant)
    {
        if (!isOccupiedByPlant)
        {
            GameObject sapling = Instantiate(plant, transform.position, Quaternion.identity);
            sapling.GetComponent<Plant>().SetBaseGround(this);
            isOccupiedByPlant = true;
        }
    }
    private void EnterState(GroundStates state)
    {
        currentState = state;
        Sprite sprite = SpriteMap[state];
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


