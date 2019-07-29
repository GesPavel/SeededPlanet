using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HandController : MonoBehaviour
{
    public KeyCode useButton, interactButton,takeItemfFromGround;
    public float staminaLossPerInstrumentUse = 5;
    public GameObject Item { get; private set; }
    StaminaDirector stamina;
    PlayerController playerController;
    Inventory inventory;

    private void Start()
    {
        stamina = FindObjectOfType<StaminaDirector>();
        playerController = GetComponentInParent<PlayerController>();
        inventory=GetComponentInParent<Inventory>();
    }
    private void Update()
    {
        if (Item != null)
        {
            Item.transform.position = transform.position;
            Item.transform.up = transform.up;
            inventory.activeItemSlot.Set(Item);
        }
        else
        {
            inventory.activeItemSlot.Remove();
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetKeyDown(useButton)) UseItem();
        if (Input.GetKeyDown(interactButton)) InteractWithTheEnvironment();
    }

    private void UseItem()
    {
        if (Item == null) return;
        if (Item.GetComponent<IUsable>() == null) return;

        if (Item.GetComponent<IGroundItem>() != null)
        {
            IGroundItem instrument = Item.GetComponent<IGroundItem>();
            if (instrument == null) return;
            instrument.Use(playerController.GetCurrentGroundPosition());
            stamina.DecreaseStamina(staminaLossPerInstrumentUse);
        }
        else if (Item.GetComponent<IEdibleItem>() != null)
        {
            IEdibleItem food = Item.GetComponent<IEdibleItem>();
            stamina.IncreaseStamina(food.StaminaRestoration);
            Destroy(Item);
            Item = null;
        }
        else if (Item.GetComponent<INonGroundItem>() != null)
        {
            INonGroundItem thing = Item.GetComponent<INonGroundItem>();
            if (thing == null) return;
            thing.Use();
            stamina.DecreaseStamina(staminaLossPerInstrumentUse);
        }

    }
    private void InteractWithTheEnvironment()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("BlockingLayer"));
        if (hit.collider == null)
        {
            Item = null;
            return;
        }

        GameObject environment = hit.collider.gameObject;
        IInteractable interactable = environment.GetComponent<IInteractable>();
        if (interactable == null)
        {
            Item = null;
            return;
        }

        ICrate crate = environment.GetComponent<ICrate>();
        IConvertor convertor = environment.GetComponent<IConvertor>();
        IFurniture furniture = environment.GetComponent<IFurniture>();
        if (crate != null)
        {
            Item = crate.ChangeItem(Item);
        }
        else if (convertor != null)
        {
            Item = convertor.Convert(Item);
        }
        else if (furniture != null)
        {
            furniture.Interact();
        }
    }
    public void PickUpItem(GameObject item)
    {
        this.Item = item;
    }
    public bool IsEmpty()
    {
        return Item == null;
    }
}
