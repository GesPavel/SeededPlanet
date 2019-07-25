using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour, Instrument,IItem
{
    PlayerController player;
    Ground standingGround;

    public string ObjectsName => throw new System.NotImplementedException();

    void Start()
    {

    }


    void Update()
    {

    }

    public void Use(Ground ground)
    {
        if (ground != null)
        {
                ground.Plow();
        }
    }

}
