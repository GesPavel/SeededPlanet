using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour, Instrument,IItem
{
    public float portionPerUse = 25.0f;
    [SerializeField] private string objectsName;
    public string ObjectsName => objectsName;

    public void Use(Ground ground)
    {
        ground.AddFertilizer(portionPerUse);
    }
}
