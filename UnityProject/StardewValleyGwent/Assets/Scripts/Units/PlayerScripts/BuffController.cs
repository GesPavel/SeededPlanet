using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    public float timeToBuffSpeed;
    float startSpeed;
    float startBuffTime;
    PlayerController player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        startSpeed = player.speed;
        startBuffTime = timeToBuffSpeed;
    }
    void CheckSpeedBuff()
    {
        if (player.speed != startSpeed)
        {
            if (timeToBuffSpeed > 0)
            {
                timeToBuffSpeed -= Time.deltaTime;
            }
            if (timeToBuffSpeed <= 0)
            {
                player.speed = startSpeed;
                timeToBuffSpeed = startBuffTime;
            }
        }
    }

    void Update()
    {
        CheckSpeedBuff();
    }
    
}
