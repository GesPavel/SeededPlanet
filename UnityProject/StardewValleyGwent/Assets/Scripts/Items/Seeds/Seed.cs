﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, Instrument,IItem
{
    PlayerController player;
    public Ground StandingGround { get; private set; }
    [SerializeField] private string objectsName;
    public string ObjectsName => objectsName;

    public GameObject plant;


    public void Use(Ground ground)
    {
        if (ground != null)
        {
            if (ground.isOccupiedByPlant) return;
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