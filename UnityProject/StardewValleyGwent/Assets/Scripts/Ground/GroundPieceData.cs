using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlowedGroundInfo : MonoBehaviour
{
    
    public static float maxWaterValue = 25;
    public static float waterDryPerSecond;
    public bool isOccupied = false;

    [HideInInspector] public float currentWaterCount;

    private void Start()
    {
        gameObject.GetComponent<UnPlowed>().ChangeState();
    }
    private void Update()
    {
        Dry();
    }
    public void AddWater(float water)
    {
        waterDryPerSecond = Time.deltaTime;
        if (currentWaterCount == 0)
            GetComponent<UnWateredPlowed>().ChangeState();
        currentWaterCount += water;
        if (currentWaterCount > maxWaterValue)
            currentWaterCount = maxWaterValue;
    }
    private void Dry()
    {

        if (currentWaterCount > 0)
        {
            currentWaterCount -= waterDryPerSecond;
            if (currentWaterCount < 0)
                currentWaterCount = 0;
        }
        else
            if (gameObject.GetComponent<WateredPlowed>())
            gameObject.GetComponent<WateredPlowed>().ChangeState();
    }
}


