using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enm : MonoBehaviour
{
    public enum PossibleNearestAnimals { Cat}

    public Dictionary<PossibleNearestAnimals, bool> AnimalIsNear { get; private set; }

    private void Start()
    {
        AnimalIsNear = new Dictionary<PossibleNearestAnimals, bool>();
        foreach (bool isanimalNear in AnimalIsNear.Values) ;
    }
}
