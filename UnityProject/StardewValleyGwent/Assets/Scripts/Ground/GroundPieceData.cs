using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPieceData : MonoBehaviour
{
    public Sprite wateredPlowedSprite;
    public Sprite unWateredPlowedSprite;
    public static float maxWaterValue = 25;
    public static float waterDryPerSecond;

    [HideInInspector] public float currentWaterCount;


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


