using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
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
        try
        {
            if (item != null)
            {
                int buyingPrice = DeterminePrice(item);
                playersMoney.AddMoney(buyingPrice);
                Destroy(item);
                Debug.Log(MoneyController.CurrentSum);
                return null;
            }
            else
            {
                int sellingPrice = (int)(DeterminePrice(itemToSell) * margin);
                if (playersMoney.IsAbleToPay(sellingPrice))
                {
                    playersMoney.Subtract(sellingPrice);
                    return Instantiate(itemToSell);
                }
                else
                {
                    throw new Exception("Недостаточно денег чтобы купить " + itemToSell.name);
                }
            }
        } catch(Exception e)
        {
            Debug.Log(e.Message);
            return item;
        }
    }
    private int DeterminePrice(GameObject item)
    {
        return priceList.GetPriceOf(item);
    }
}
