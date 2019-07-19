using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, Instrument
{
    public static float water = 0;
    public static float maxWaterVolume = 100;
    public static float waterPerUse = 25;
    PlayerController player;
    Ground standingGround;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Use()
    {

        if (standingGround == null) return;
            if (water >= waterPerUse)
            {
                standingGround.AddWater(waterPerUse);
                water -= waterPerUse;
            }   
    }

    public void FillUp()
    {
        water = maxWaterVolume;
        Debug.Log($"Current water = {water}");
    }
}
