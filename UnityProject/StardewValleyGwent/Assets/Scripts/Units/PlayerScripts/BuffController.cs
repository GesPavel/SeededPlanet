using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    public float timeToBuffSpeed;
    float startSpeed;
    float startSpeedBuffTime;
    PlayerController player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        startSpeed = player.speed;
        startSpeedBuffTime = timeToBuffSpeed;
    }
    void CheckSpeedBuff()
    {
        if (player.speed != startSpeed)
        {
            if (timeToBuffSpeed > 0.0f)
            {
                timeToBuffSpeed -= Time.deltaTime;
            }
            if (timeToBuffSpeed <= 0.0f)
            {
                player.speed = startSpeed;
                timeToBuffSpeed = startSpeedBuffTime;
            }
        }
    }

    void Update()
    {
        CheckSpeedBuff();
    }
    
}
