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
            else if (item.GetComponent<IEatable>() != null)
            {
                IEatable food = item.GetComponent<IEatable>();
                stamina.IncreaseStamina(food.StaminaRestoration);
                Destroy(item);
                item = null;
            }
            else if (item.GetComponent<Seed>() != null)
            {
                Seed seed = item.GetComponent<Seed>();
                Ground ground = seed.StandingGround?.GetComponent<Ground>();
                if(ground!=null)
                {
                    if (ground.isOccupied) return;
                    if(!ground.IsPlowed)
                    {
                        Destroy(item.gameObject);
                        return;
                    }
                    ground.AddPlant(seed.plant);
                    Destroy(item.gameObject);
                }

            }
        }
    }
    private void InteractWithTheEnvironment()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("BlockingLayer"));
        GameObject enviroment = hit.collider.gameObject;
        if (hit.collider != null)
        {
            Debug.Log($"Player interact with {hit.collider.gameObject.name}");
            if (enviroment.GetComponent<ToolBar>() != null)
            {
                ToolBar toolbar = hit.collider.GetComponent<ToolBar>();
                GameObject instument = toolbar.SendItem();
                toolbar.SetItem(item);
                item = instument;
            }
            else if (enviroment.GetComponent<SeedCrate>() != null)
            {
                SeedCrate seedCrate = hit.collider.GetComponent<SeedCrate>();
                if (item == null) item = seedCrate.SendItem();
                else if (item != null && item.GetComponent<Seed>() != null)
                {
                    seedCrate.SetItem(item);
                    item = null;
                }
            }
            else if (enviroment.GetComponent<VeggieCrate>() != null)
            {
                VeggieCrate veggieCrate = hit.collider.GetComponent<VeggieCrate>();
                if (item == null) item = veggieCrate.SendItem();
                else if (item != null && item.GetComponent<Vegetable>() != null)
                {
                    veggieCrate.SetItem(item);
                    item = null;
                }
            }
            else if (enviroment.tag == "Well")
            {
                item?.GetComponent<WateringCan>()?.FillUp();
            }

            else if (enviroment.GetComponent<Bed>() != null)
            {
                FindObjectOfType<PlayerController>().GoToBed();
            }
            else if (enviroment.GetComponent<Merchant>() != null)
            {
                Merchant merchant = enviroment.GetComponent<Merchant>();
                item = merchant.Trade(item);
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
