using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferItemScript : MonoBehaviour
{
    private GameObject item;
    private GameObject player;
    public KeyCode use;
    void Start()
    {
        player = (GetComponentInParent<PlayerController>() as PlayerController).gameObject;
    }

    void Update()
    {
        if (item != null)
        {
            item.transform.position = transform.position;
            if(player!=null) item.transform.up = player.transform.up;
        }
        if (Input.GetKeyDown(use) && item?.gameObject.tag == "Hoe" && player.GetComponent<PlayerController>().currentGroundPosition as UnPlowed!=null) {

            if (player.GetComponent<PlayerController>().currentGroundPosition == null) return;
            player.GetComponent<PlayerController>().currentGroundPosition.UseItem(); Debug.Log("use");
        }
        if (Input.GetKeyDown(use) && item?.gameObject.tag == "WateringCan" && player.GetComponent<PlayerController>().currentGroundPosition as UnWateredPlowed != null)
        {

            if (player.GetComponent<PlayerController>().currentGroundPosition == null) return;
            player.GetComponent<PlayerController>().currentGroundPosition.UseItem(); Debug.Log("use");
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
