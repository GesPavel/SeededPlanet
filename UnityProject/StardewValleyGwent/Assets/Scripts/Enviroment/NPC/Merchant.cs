using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    //    MoneyController playersMoney;
    public GameObject itemToSell;
    [SerializeField] private float margin = 1.2f;
    private void Start()
    {
//        playersMoney = FindObjectOfType<MoneyController>();
    }

    public GameObject Trade(GameObject item)
    {
        try
        {
            if (item != null)
            {
                int buyingPrice = DeterminePrice(item);
                return null;
            }
            else
            {
                int sellingPrice = (int)(DeterminePrice(itemToSell) * margin);
                return itemToSell;
            }
        } catch(Exception e)
        {
            Debug.Log(e.Message);
            return item;
        }
    }

    

    private int DeterminePrice(GameObject item)
    {
        return PriceList.GetPriceOf(item);
    }
}
