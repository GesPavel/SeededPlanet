using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HandController : MonoBehaviour
{
    public KeyCode actionButton, TakePutButton, InventoryButton;
    public GameObject ItemInHand { get; private set; }
    public LayerMask itemsLayer;
    public string sortingLayerItemsOnFloor = "ItemOnFloor";
    public string sortingLayerItemsOnUnits = "ItemOnUnit";
    public float staminaLossPerInstrumentUse = 5;
    public Image takingIndickator;

    private GameObject nearestItem;
    private InventoryScript inventory;
    private StaminaDirector stamina;
    private PlayerController playerController;
    private float playersHandLength = 0.5f;
    private float timeDelayBeforTakeItem = 0.5f;
    private float TakePutButtonHoldedTime = 0;
    private bool IsTakePutButtonHolded = false;
    private void Start()
    {
        stamina = FindObjectOfType<StaminaDirector>();
        playerController = GetComponentInParent<PlayerController>();
        inventory = InventoryScript.instance;
    }
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetKeyDown(InventoryButton))
        {
            OpenCloseInventory();
        }
        PickUpAndDropLogic();
        if (Input.GetKeyDown(actionButton) && InteractWithTheEnvironment()) { }
        else if (Input.GetKeyDown(actionButton) && IsHasItemInHand() && UseItem()) { }
    }

    private void PickUpAndDropLogic()
    {
        if (Input.GetKeyDown(TakePutButton))
        {
            RaycastHit2D raycastHit2 = FindNearestItemsHit();
            nearestItem = ExtractItemObjectFromHit2D(raycastHit2);
            IsTakePutButtonHolded = true;
        }
        if (IsTakePutButtonHolded && Input.GetKey(TakePutButton) && (nearestItem!=null || IsHasItemInHand()))
        {
            TakePutButtonHoldedTime += Time.deltaTime;
            takingIndickator.fillAmount += (1 / timeDelayBeforTakeItem) * Time.deltaTime;
            if (TakePutButtonHoldedTime >= timeDelayBeforTakeItem)
            {
                if (IsHasItemInHand())
                {
                    DropItemFromHand();
                }
                if (nearestItem)
                {
                    TakeItem(nearestItem);
                }
                ResetHolding();
            }
        }
        if (Input.GetKeyUp(TakePutButton) && IsTakePutButtonHolded)
        {
            if (nearestItem)
            {
                inventory.TryPutItem(nearestItem);
            }
            ResetHolding();
        }
    }
    private RaycastHit2D FindNearestItemsHit()
    {
        if (IsHasItemInHand())
        {
            ItemInHand.GetComponent<Collider2D>().enabled = false;
        }
        RaycastHit2D nearestItem = Physics2D.Raycast(playerController.gameObject.transform.position, transform.up, playersHandLength, itemsLayer);
        if (IsHasItemInHand())
        {
            ItemInHand.GetComponent<Collider2D>().enabled = true;
        }
        return nearestItem;
    }
    private GameObject ExtractItemObjectFromHit2D(RaycastHit2D hit)
    {
        if (hit.collider == null)
        {
            return null;
        }
        IItem item = hit.collider.gameObject.GetComponent<IItem>();
        if (item == null)
        {
            return null;
        }
        return hit.collider.gameObject;
    }
    private void ResetHolding()
    {
        TakePutButtonHoldedTime = 0;
        IsTakePutButtonHolded = false;
        takingIndickator.fillAmount = 0;
    }
    public void DropItemFromHand()
    {
        ItemInHand.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerItemsOnFloor;
        ItemInHand.transform.SetParent(null);
        ItemInHand = null;
    }
    public void TakeItem(GameObject item)
    {
        ItemInHand = item;
        ItemInHand.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerItemsOnUnits;
        ItemInHand.transform.SetParent(playerController.gameObject.transform);
        ItemInHand.transform.position = transform.position;
    }
    private void OpenCloseInventory()
    {
        if (inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(false);
        }
        else
        {
            inventory.gameObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if (IsHasItemInHand())
        {
            MoveItem();
        }
    }

    private void MoveItem()
    {
        ItemInHand.transform.position = transform.position;
        ItemInHand.transform.up = transform.up;
    }
    private bool IsHasItemInHand()
    {
        if (ItemInHand)
        {
            return true;
        }
        else return false;
    }
    private bool UseItem()
    {
        if (ItemInHand.GetComponent<IGroundItem>() != null)
        {
            IGroundItem instrument = ItemInHand.GetComponent<IGroundItem>();
            instrument.Use(playerController.GetCurrentGroundPosition());
            stamina.DecreaseStamina(staminaLossPerInstrumentUse);
            return true;
        }
        else if (ItemInHand.GetComponent<IEdibleItem>() != null)
        {
            IEdibleItem food = ItemInHand.GetComponent<IEdibleItem>();
            stamina.IncreaseStamina(food.StaminaRestoration);
            if (ItemInHand.GetComponent<IBuffable>() != null)
            {
                IBuffable buffFood = ItemInHand.GetComponent<IBuffable>();
                buffFood.Buff();
            }
            Destroy(ItemInHand);
            ItemInHand = null;
            return true;
        }
        else if (ItemInHand.GetComponent<INonGroundItem>() != null)
        {
            INonGroundItem thing = ItemInHand.GetComponent<INonGroundItem>();
            if (thing == null) return false;
            thing.Use();
            stamina.DecreaseStamina(staminaLossPerInstrumentUse);
            return true;
        }
        return false;
    }
    private bool InteractWithTheEnvironment()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("BlockingLayer"));
        if (hit.collider == null)
        {
            return false;
        }
        GameObject environment = hit.collider.gameObject;
        IInteractable interactable = environment.GetComponent<IInteractable>();
        if (interactable == null)
        {
            return false;
        }

        ICrate crate = environment.GetComponent<ICrate>();
        if (crate != null)
        {
            GameObject itemFromHand = ItemInHand;
            if (IsHasItemInHand())
            {
                DropItemFromHand();
            }
            GameObject itemFromCrate = crate.TradeItem(itemFromHand);   
            if (itemFromCrate)
            {
                TakeItem(itemFromCrate);
            }
            return true;
        }
        IConverter convertor = environment.GetComponent<IConverter>();
        if (convertor != null && IsHasItemInHand())
        {
            GameObject itemFromHand = ItemInHand;
            GameObject itemFromConvertor = convertor.Convert(itemFromHand);
            DropItemFromHand();
            TakeItem(itemFromConvertor);
            return true;
        }
        IFurniture furniture = environment.GetComponent<IFurniture>();
        if (furniture != null)
        {
            furniture.Interact();
            return true;
        }
        Merchant merchant = environment.GetComponent<Merchant>();
        if (merchant != null)
        {
            GameObject ItemFromMerchant = merchant.Trade(ItemInHand);
            if (ItemFromMerchant != null)
            {
                TakeItem(ItemFromMerchant);
            }
            else
            {
                Destroy(ItemFromMerchant);
                ItemInHand = null;
            }
            return true;
        }
        return false;
    }

}
