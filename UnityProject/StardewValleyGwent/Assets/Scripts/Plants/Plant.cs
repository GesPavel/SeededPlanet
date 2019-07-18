using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    [SerializeField] private float growthTime;
    [SerializeField] private GameObject vegetable;
    [HideInInspector] public Ground ground;
    private PlantStates currentState;
    private Dictionary<PlantStates, Sprite> SpriteMap;
    private float timer;
    enum PlantStates
    {
        Sprout,
        Sapling,
        BiggerSapling,
        GrownPlant
    }
    void Start()
    {
        FillMap();
        EnterState(0); // Самое первое состояние растение
    }

    private void FillMap()
    {
        SpriteMap = new Dictionary<PlantStates, Sprite>();
        SpriteVault vault = FindObjectOfType<SpriteVault>();
        SpriteMap.Add(PlantStates.Sprout, vault.sproutStateSprite);
        SpriteMap.Add(PlantStates.Sapling, vault.saplingStateSprite);
        SpriteMap.Add(PlantStates.BiggerSapling, vault.biggerSaplingStateSprite);
        SpriteMap.Add(PlantStates.GrownPlant, vault.grownStateSplrite);
    }

    private void EnterState(PlantStates state)
    {
        currentState = state;
        GetComponent<SpriteRenderer>().sprite = SpriteMap[state];
    }
    private PlantStates NextState()
    {
        int nextState = (int)currentState + 1;
        if (nextState == Enum.GetValues(typeof(PlantStates)).Length)
            nextState = 0;
        return (PlantStates)nextState;
    }

    
    void InstantiateVegetable()
    {
        Instantiate(vegetable, transform.position, Quaternion.identity)
            .GetComponent<Vegetable>().SetPieceGround(ground);
        Destroy(this.gameObject);
    }

    public void SetBaseGround(Ground ground)
    {
        this.ground = ground;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > growthTime / Enum.GetValues(typeof(PlantStates)).Length + 1)
        {
            if (currentState == PlantStates.GrownPlant)
                InstantiateVegetable();
            EnterState(NextState());
            timer = 0;
        }
    }  
}
