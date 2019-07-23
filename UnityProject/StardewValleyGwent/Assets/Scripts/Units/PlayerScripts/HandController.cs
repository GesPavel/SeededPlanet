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
        else if (item.GetComponent<IEdible>() != null)
        {
            IEdible food = item.GetComponent<IEdible>();
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
            GameObject environment = hit.collider.gameObject;

            if (environment.GetComponent<ToolBar>() != null)
            {
                ToolBar toolbar = hit.collider.GetComponent<ToolBar>();
                GameObject instument = toolbar.SendItem();
                toolbar.SetItem(item);
                item = instument;
            }
            else if (environment.GetComponent<SeedCrate>() != null)
            {
                SeedCrate seedCrate = hit.collider.GetComponent<SeedCrate>();
                if (item == null) item = seedCrate.SendItem();
                else if (item != null && item.GetComponent<Seed>() != null)
                {
                    seedCrate.SetItem(item);
                    item = null;
                }
            }
            else if (environment.GetComponent<VeggiesCrate>() != null)
            {
                VeggiesCrate veggiesCrate = hit.collider.GetComponent<VeggiesCrate>();
                if (item == null) item = veggiesCrate.SendItem();
                else if (item != null && item.GetComponent<Vegetable>() != null)
                {
                    veggiesCrate.SetItem(item);
                    item = null;
                }
            }
            else if (environment.tag == "Well")
            {
                item?.GetComponent<WateringCan>()?.FillUp();
            }

            else if (environment.GetComponent<Bed>() != null)
            {
                playerController.GoToBed();
            }
            else if (environment.GetComponent<Merchant>() != null)
            {
                Merchant merchant = environment.GetComponent<Merchant>();
                item = merchant.Trade(item);
            }
            else if (environment.GetComponent<KitchenStove>() != null)
            {
                KitchenStove stove = environment.GetComponent<KitchenStove>();
                item = stove.Interact(item);
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
