using System;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    [SerializeField] private float growthTime = 5;
    public GameObject[] vegetable;
    public Ground ground;
    private PlantStates currentState;
    private Dictionary<PlantStates, Sprite> SpriteMap;
    private float timer;
    private int stateNumber;

    enum PlantStates
    {
        Sprout,
        Sapling,
        BiggerSapling,
        GrownPlant,
        Vegetable
    }
    void Start()
    {
        FillSpriteMap();
        EnterState(PlantStates.Sprout);
        stateNumber = Enum.GetValues(typeof(PlantStates)).Length;
    }

    private void FillSpriteMap()
    {
        SpriteMap = new Dictionary<PlantStates, Sprite>();
        SpriteVault vault = FindObjectOfType<SpriteVault>();
        SpriteMap.Add(PlantStates.Sprout, vault.sproutStateSprite);
        SpriteMap.Add(PlantStates.Sapling, vault.saplingStateSprite);
        SpriteMap.Add(PlantStates.BiggerSapling, vault.biggerSaplingStateSprite);
        SpriteMap.Add(PlantStates.GrownPlant, vault.grownStateSplrite);
        SpriteMap.Add(PlantStates.Vegetable, null);

    }
    private void EnterState(PlantStates state)
    {
        currentState = state;
        GetComponent<SpriteRenderer>().sprite = SpriteMap[state];
    }
    private PlantStates NextState()
    {
        return currentState + 1;
    }
    private void EnterNextState()
    {
        EnterState(NextState());
    }

    public virtual void InstantiateVegetable()
    {
        GameObject newVegetable = Instantiate(vegetable[UnityEngine.Random.Range(0, vegetable.Length)], transform.position, Quaternion.identity);
        ground.isOccupiedByPlant = false;
        if (newVegetable.GetComponent(typeof(Vegetable)))
        {
            newVegetable.AddComponent<HarvestTask>();
        }
        else if (newVegetable.GetComponent<RobotChargeStation>() != null)
        {
            Destroy(ground.gameObject); 
        }
    }

    public void SetBaseGround(Ground ground)
    {
        this.ground = ground;
    }
    public virtual void Update()
    {
        timer += Time.deltaTime;
        float growthTimePerPhase = DetermineGrowthTime();

        if (timer > growthTimePerPhase)
        {
            EnterNextState();
            if (currentState == PlantStates.Vegetable)
            {
                InstantiateVegetable();
                Destroy(this.gameObject);
            }
            timer = 0.0f;
        }

    }

    private float DetermineGrowthTime()
    {
        float groundDependentCoefficent = DetermineGroundDependentCoefficent();
        float averageGrowthPerPhase = (growthTime * groundDependentCoefficent) / stateNumber;
        return averageGrowthPerPhase;
    }

    private float DetermineGroundDependentCoefficent()
    {
        const float WATER_BUFF = 1.8f;
        const float DEFAULT_SPEED_COEFFICIENT = 1.0f;
        if (ground.IsWatered)
            return WATER_BUFF;
        else
            return DEFAULT_SPEED_COEFFICIENT;
    }
}
