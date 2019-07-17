using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public KeyCode useButton,interactButton;
    GameObject item;
    
    private void Update()
    {
        if (item != null)
        {
            item.transform.position = transform.position;
            item.transform.up = transform.up;
        }
        if (Input.GetKeyDown(useButton)) UseItem();
        if (Input.GetKeyDown(interactButton)) InteractWithTheEnvironment();
    }

    private void UseItem()
    {
        Instrument instrument = item?.GetComponent<Instrument>();
        instrument?.Use();
        if (instrument != null) Debug.Log($"Instrument {item.gameObject.name} used.");
    }
    private void InteractWithTheEnvironment()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("BlockingLayer"));
        if (hit.collider != null)
        {
            Debug.Log($"Player interact with {hit.collider.gameObject.name}");
            if (hit.collider.gameObject.GetComponent<ToolBar>() != null)
            {
                ToolBar toolbar = hit.collider.GetComponent<ToolBar>();
                GameObject instument = toolbar.GetItem();
                toolbar.SetItem(item);
                item = instument;
            }
        }
    }


}
