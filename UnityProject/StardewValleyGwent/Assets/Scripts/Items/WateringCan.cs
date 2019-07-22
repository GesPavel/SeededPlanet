﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, Instrument
{
    public static float water = 0;
    public static float maxWaterVolume = 100;
    public static float waterPerUse = 25;
    PlayerController player;
    Ground standingGround;
    public void Use(Ground ground)
    {

        if (ground == null) return;
        if (water >= waterPerUse)
        {
            ground.AddWater(waterPerUse);
            water -= waterPerUse;
            Debug.Log(water);
        }
    }

    public void FillUp()
    {
        water = maxWaterVolume;
        Debug.Log($"Current water = {water}");
    }
}
