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

    public void InteractWithCrate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1,LayerMask.GetMask("BlockingLayer"));
        
        if (hit.collider?.tag == "ToolBar" && this.CompareTag("RightHand"))
        {
            hit.collider.GetComponent<ToolBar>().TakeOrPutItem(this);
        }
        else if (hit.collider?.tag == "SeedCrate" && this.CompareTag("LeftHand"))
        {
            hit.collider.GetComponent<SeedCrate>().TakeOrPutItem(this);
        }

    }
    public void setItem(GameObject item)
    {
        this.item = item;
    }
    public GameObject SendItem()
    {
        return item;
    }

    public void RemoveItem()
    {
        item = null;
    }
    public bool IsWithItem()
    {
        if (item != null) return true;
        else return false;
    }
}
