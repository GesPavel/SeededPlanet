using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public KeyCode useButton, interactButton;
    public float staminaLossPerInstrumentUse = 5;
    GameObject item;
    StaminaDirector stamina;
    PlayerController playerController;

    private void Start()
    {
        stamina = FindObjectOfType<StaminaDirector>();
        playerController = GetComponentInParent<PlayerController>();
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
        if (item == null) return;
        if (item.GetComponent<IUsable>() == null) return;

        if (item.GetComponent<Instrument>() != null)
        {
            Instrument instrument = item.GetComponent<Instrument>();
            if (instrument == null) return;
            instrument.Use(playerController.GetCurrentGroundPosition());
            stamina.DecreaseStamina(staminaLossPerInstrumentUse);
        }
        else if (item.GetComponent<IEatable>() != null)
        {
            IEatable food = item.GetComponent<IEatable>();
            stamina.IncreaseStamina(food.StaminaRestoration);
            Destroy(item);
            item = null;
        }

    }
    private void InteractWithTheEnvironment()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("BlockingLayer"));

        if (hit.collider != null)
        {
            GameObject enviroment = hit.collider.gameObject;

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
                playerController.GoToBed();
            }
            else if (enviroment.GetComponent<Merchant>() != null)
            {
                Merchant merchant = enviroment.GetComponent<Merchant>();
                item = merchant.Trade(item);
            }
            else if (enviroment.GetComponent<Kitchen>() != null)
            {
                Kitchen kitchen = enviroment.GetComponent<Kitchen>();
                item = kitchen.Interact(item);
            }
        }
    }

    public void PickUpItem(GameObject item)
    {
        this.item = item;
    }
    public bool IsEmpty()
    {
        return item == null;
    }
}
