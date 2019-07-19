﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    Ground ground;
    PlayerController player;
    Ground standingGround;
    public GameObject egg;
    void Start()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Ceil(pos.x)+0.5f;
        pos.y = Mathf.Ceil(pos.y)+0.5f;
        transform.position = pos;
    }


}
