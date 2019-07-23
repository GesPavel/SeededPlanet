using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour, Instrument
{
    PlayerController player;
    Ground standingGround;

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
