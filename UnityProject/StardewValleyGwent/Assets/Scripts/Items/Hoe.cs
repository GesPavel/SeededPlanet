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
        UnPlowed ground = standingGround.GetComponent<UnPlowed>();
        if (ground != null)
        {
            ground.ChangeState();
        }
    }

   
}
