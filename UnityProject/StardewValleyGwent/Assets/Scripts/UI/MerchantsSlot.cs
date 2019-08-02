using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantsSlot : MonoBehaviour
{
    [SerializeField] private Sprite emptySlot;
    [SerializeField] private Image icon;
    [SerializeField] private Text productsName;
    private string itemsName;
    public void Set(GameObject item)
    {
        icon.sprite = item.GetComponent<SpriteRenderer>().sprite;
        itemsName = item.GetComponent<IItem>().ObjectsName;
        productsName.text = item.GetComponent<IItem>().ObjectsName;
        
    }
    private void OnEnable()
    {
        getItemsName += Merchant.instance.TrySellItemToPlayer;
    }

    public void OnClickItem()
    {
        getItemsName(itemsName);
    }

    public delegate void OnClick(string itemsName);

    public event OnClick getItemsName;

}
