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

    public void Use()
    {
        player = FindObjectOfType<PlayerController>();
        standingGround = player.GetCurrentGroundPosition();
        if (standingGround != null)
        {
                standingGround.Plow();
        }
    }


}
