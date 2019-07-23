﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, Instrument
{
    PlayerController player;
    public Ground StandingGround { get; private set; }
    public GameObject plant;

    public void Use(Ground ground)
    {
        if (ground != null)
        {
            if (ground.isOccupied) return;
            if (!ground.IsPlowed)
            {
                Destroy(this.gameObject);
                return;
            }
            ground.AddPlant(this.plant);
            Destroy(this.gameObject);
        }
    }
}