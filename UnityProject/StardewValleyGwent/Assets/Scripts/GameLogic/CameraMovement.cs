using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    Vector3 pos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pos = player.transform.position;
        pos.z = -10;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            pos = player.transform.position;
            pos.z = -10;
            transform.position = pos;
        }
    }
}
