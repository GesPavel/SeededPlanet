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
        if (hit.collider == null)
        {
            item = null;
            return;
        }

        GameObject environment = hit.collider.gameObject;
        IInteractable interactable = environment.GetComponent<IInteractable>();
        if (interactable == null)
        {
            item = null;
            return;
        }

        ICrate crate = environment.GetComponent<ICrate>();
        IConvertor convertor = environment.GetComponent<IConvertor>();
        IFurniture furniture = environment.GetComponent<IFurniture>();
        if (crate != null)
        {
            item = crate.ChangeItem(item);
        }
        else if (convertor != null)
        {
            item = convertor.Convert(item);
        }
        else if (furniture != null)
        {
            furniture.Interact();
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
