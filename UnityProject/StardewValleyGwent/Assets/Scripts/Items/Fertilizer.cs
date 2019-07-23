using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour, Instrument
{
    public float portionPerUse = 25.0f;
   public void Use(Ground ground)
    {
        ground.AddFertilizer(portionPerUse);
    }
}
