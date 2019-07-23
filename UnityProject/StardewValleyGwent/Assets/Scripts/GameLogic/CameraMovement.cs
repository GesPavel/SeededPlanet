using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    Vector3 cameraPosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        cameraPosition = player.transform.position;
        cameraPosition.z = -10;
        transform.position = cameraPosition;
    }

    void Update()
    {
        if (player == null) 
            player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            cameraPosition = player.transform.position;
            cameraPosition.z = -10;
            transform.position = cameraPosition;
        }
    }
    
}
