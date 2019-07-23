using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    private GameObject player;
    bool playersPositionChanged;
    void Start()
    {
        playersPositionChanged = false;       
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!playersPositionChanged)
            {
                player.transform.position = this.transform.position;
                playersPositionChanged = true;
            }
        }
    }
}
