using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Sprite placeHolder;
    [SerializeField] private Image itemsIcon;
    private string itemsName;
    private ItemsHolder itemsHolder;

    private void Start()
    {
        itemsHolder = ItemsHolder.instance;
    }
    public bool IsFool { get; private set; } = false;
    public void Set(GameObject item)
    {
        itemsIcon.sprite = item.GetComponent<SpriteRenderer>().sprite;
        itemsName = item.GetComponent<IItem>().ObjectsName;
        IsFool = true;
    }

    public void Remove()
    {
        itemsIcon.sprite = placeHolder;
        itemsName = null;
        IsFool = false;
    }

    public void Drop()
    {
        var droppedObject = itemsHolder.GetItemByName(itemsName);
        Remove();
        if (droppedObject == null)
        {
            return;
        }
        droppedObject.transform.position=FindObjectOfType<PlayerController>().transform.position;
    }
    public void PutOtemInHand()
    {
        HandController handController = FindObjectOfType<HandController>();
        var objectToHand = itemsHolder.GetItemByName(itemsName);
        Remove();
        if (handController.Item != null)
        {
            Set(handController.Item);
            Destroy(handController.Item);
        }
        handController.PickUpItem(objectToHand);

    }
}
