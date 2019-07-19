using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public KeyCode useButton, interactButton;
    GameObject item;
    StaminaDirector stamina;
    public float staminaLossPerInstrumentUse = 5;
    private void Start()
    {
        stamina = FindObjectOfType<StaminaDirector>();
    }
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
        if (item != null)
        {
            if (item.GetComponent<Instrument>() != null)
            {
                Instrument instrument = item?.GetComponent<Instrument>();
                instrument?.Use();
                stamina.DecreaseStamina(staminaLossPerInstrumentUse);
                if (instrument != null) Debug.Log($"Instrument {item.gameObject.name} used.");
            }
            else if (item.GetComponent<Vegetable>() != null)
            {
                Vegetable vegetable = item.GetComponent<Vegetable>();
                stamina.IncreaseStamina(vegetable.staminaRestoration);
                Destroy(item);
                item = null;
            }
            else if (item.GetComponent<Seed>() != null)
            {
                item.GetComponent<Seed>().Use();
            }
        }
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
                GameObject instument = toolbar.SendItem();
                toolbar.SetItem(item);
                item = instument;
            }
            else if (hit.collider.gameObject.GetComponent<SeedCrate>() != null)
            {
                SeedCrate seedCrate = hit.collider.GetComponent<SeedCrate>();
                if (item == null) item = seedCrate.SendItem();
                else if (item != null && item.GetComponent<Seed>()!=null)
                {
                    seedCrate.SetItem(item);
                    item = null;
                }
            }
            else if (hit.collider.gameObject.GetComponent<VeggieCrate>() != null)
            {
                VeggieCrate veggieCrate = hit.collider.GetComponent<VeggieCrate>();
                if (item == null) item = veggieCrate.SendItem();
                else if (item != null && item.GetComponent<Vegetable>() != null)
                {
                    veggieCrate.SetItem(item);
                    item = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Well")
            {
                item?.GetComponent<WateringCan>()?.FillUp();
            }

            else if (hit.collider.gameObject.GetComponent<Bed>() != null)
            {
                FindObjectOfType<PlayerController>().GoToBed();
            }
        }
    }

    public void PickUpItem (GameObject item)
    {
        this.item = item;
    }
    public bool IsEmpty()
    {
        return item == null;
    }
}
