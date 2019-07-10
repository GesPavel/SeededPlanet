using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferItemScript : MonoBehaviour
{
    private GameObject item;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (item != null)
        {
            item.transform.position = transform.position;
            item.transform.up = player.transform.up;
        }
    }
}
