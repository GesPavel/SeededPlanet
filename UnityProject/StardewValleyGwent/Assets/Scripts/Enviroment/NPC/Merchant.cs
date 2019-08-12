using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour, IInteractable
{
    PriceList priceList;
    MoneyController playersMoney;
    public GameObject itemToSell;
    [SerializeField] private float margin = 1.2f;
    private void Start()
    {
        playersMoney = FindObjectOfType<MoneyController>();
        priceList = GetComponent<PriceList>();
    }

    public GameObject Trade(GameObject item)
    {
            if (item != null)
            {
                return TryToBuy(item);
            }
            else
            {
                return TryToSell(item);
            }
    }
    private GameObject TryToBuy(GameObject item)
    {
        int buyingPrice = DeterminePrice(item);
        if (buyingPrice >= 0)
        {
            playersMoney.AddMoney(buyingPrice);
            Destroy(item);
            return null;
        }
        else
        {
            return item;
        }
    }
    private GameObject TryToSell(GameObject item)
    {
        int sellingPrice = (int)(DeterminePrice(itemToSell) * margin);
        if (playersMoney.IsAbleToPay(sellingPrice))
        {
            playersMoney.Subtract(sellingPrice);
            return Instantiate(itemToSell);
        }
        else
        {
            return null;
        }
    }



    private int DeterminePrice(GameObject item)
    {
        return priceList.GetPriceOf(item);
    }
}
