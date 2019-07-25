using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour, Instrument,IItem
{
    public float portionPerUse = 25.0f;

    public string ObjectsName => throw new System.NotImplementedException();

    public void Use(Ground ground)
    {
        ground.AddFertilizer(portionPerUse);
    }
}
