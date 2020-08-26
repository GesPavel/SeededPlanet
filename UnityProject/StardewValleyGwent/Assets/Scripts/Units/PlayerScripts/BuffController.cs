using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    public float timeToBuffSpeed;
    float startSpeedBuffTime;
    PlayerController player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        startSpeedBuffTime = timeToBuffSpeed;
    }
    void CheckSpeedBuff()
    {
        if (player.speed > player.startSpeed)
        {
            if (timeToBuffSpeed > 0.0f)
            {
                timeToBuffSpeed -= Time.deltaTime * Time.timeScale;
            }
            if (timeToBuffSpeed <= 0.0f)
            {
                player.ResetSpeed();
                timeToBuffSpeed = startSpeedBuffTime;
            }
        }
    }

    void Update()
    {
        CheckSpeedBuff();
    }
    
}
