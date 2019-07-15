using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
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
            if (player != null) item.transform.up = player.transform.up;
        }
        if (Input.GetKeyDown(use))
        {

            IUsable usableItem = item?.GetComponent(typeof(IUsable)) as IUsable;
            if (usableItem != null)
                usableItem.Use();
        }
    }

    public void InteractWithEnviroment()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("BlockingLayer"));

        if (hit.collider?.tag == "Crate")
        {
            ICrate crate = (ICrate)hit.collider.GetComponent(typeof(ICrate)) as ICrate;
            crate.TakeOrPutItem(this);
        }
        if (hit.collider?.tag == "Well")
        {
            hit.collider.GetComponent<Well>().Interact(this);
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
