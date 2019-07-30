using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour, IConvertor
{
    PriceList priceList;
    MoneyController playersMoney;
    HandController handController;
    [SerializeField] private float margin = 1.2f;
    ItemsHolder itemsHolder;

    #region Singleton
    public static Merchant instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    private void Start()
    {
        playersMoney = FindObjectOfType<MoneyController>();
        priceList = GetComponent<PriceList>();
        handController = FindObjectOfType<HandController>();
        itemsHolder = ItemsHolder.instance;
    }

    public GameObject Convert(GameObject item)
    {
        if (item != null)
        {
            int buyingPrice = DeterminePrice(item.GetComponent<IItem>().ObjectsName);
            playersMoney.AddMoney(buyingPrice);
            Destroy(item);          
        }
        return null;
    }
    public int DeterminePrice(string itemsName)
    {
        return priceList.GetPriceOf(itemsName);
    }

    public void TrySellItemToPlayer(string itemsName)
    {
        if (handController.Item != null)
        {
            return;
        }
        int sellingPrice = (int)(DeterminePrice(itemsName) * margin);
        if (playersMoney.IsAbleToPay(sellingPrice))
        {
            playersMoney.Subtract(sellingPrice);
            var itemToSell = itemsHolder.GetItemByName(itemsName);
            handController.PickUpItem(Instantiate(itemToSell));
        }
    }
}
