using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferItemScript : MonoBehaviour
{
    public GameObject item;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (item != null)
        {
            item.transform.position = transform.position;
            item.transform.up = player.transform.up;
        }
    }
}
