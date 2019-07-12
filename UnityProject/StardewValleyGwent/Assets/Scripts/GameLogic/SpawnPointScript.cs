using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    private GameObject player;
    bool playersPositionchanged;
    void Start()
    {
        playersPositionchanged = false;       
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!playersPositionchanged)
            {
                player.transform.position = this.transform.position;
                playersPositionchanged = true;
            }
        }
    }
}
