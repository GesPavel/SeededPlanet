using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour, Instrument
{
    PlayerController player;
    GameObject standingGround;

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
            UnPlowed ground;
            if (standingGround.GetComponent<UnPlowed>() as UnPlowed)
            {
                ground = standingGround.GetComponent<UnPlowed>();
                ground.ChangeState();
            }
        }
    }


}
