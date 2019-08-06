using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image icon;
    private GameObject itemObject;
    private Transform dragParent;
    private Transform slotHolder;
    public bool IsFull { get; private set; } = false;
    private void Start()
    {
        icon.preserveAspect = true;
    }
    public void FillSlot(GameObject obj)
    {
        icon.sprite = obj.GetComponent<IItem>().Icon;
        itemObject = obj;
        itemObject.SetActive(false);
        IsFull = true;
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void InitTransforms(Transform slotHolder, Transform dragParent)
    {
        this.slotHolder = slotHolder;
        this.dragParent = dragParent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(dragParent);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        RectTransform slotHolderRectTransform = (RectTransform)slotHolder;
        RectTransform inventoryRectTransform = (RectTransform)InventoryScript.instance.transform;
        Vector2 localPosInSlotHolder = slotHolderRectTransform.InverseTransformPoint(icon.transform.position);
        Vector2 localPosInInventory = inventoryRectTransform.InverseTransformPoint(icon.transform.position);
        if ((slotHolderRectTransform.rect.Contains(localPosInSlotHolder) || inventoryRectTransform.rect.Contains(localPosInInventory)) &&
            InventoryScript.instance.gameObject.activeSelf)
        {
            transform.SetParent(slotHolder);
        }
        else
        {
            DropItem();
            SelfDestruction();
        }
    }
    public void DropItem()
    {
        itemObject.transform.position = FindObjectOfType<PlayerController>().transform.position;
        itemObject.SetActive(true);
        itemObject = null;
    }
    public void SelfDestruction()
    {
        InventoryScript.instance.RemoveSlot(this);
        Destroy(gameObject);
    }

    public void ChangeWithHandsItem()
    {
        Debug.Log("BUG");
        HandController handController = FindObjectOfType<HandController>();
        GameObject itemToHand = itemObject;
        GameObject itemForSlot = handController.ItemInHand;
        if (handController.ItemInHand != null)
        {
            handController.DropItemFromHand();
        }
        itemToHand.SetActive(true);
        handController.TakeItem(itemToHand);
        if (itemForSlot == null)
        {
            SelfDestruction();
        }
        else
        {
            FillSlot(itemForSlot);
        }
        
    }

}
