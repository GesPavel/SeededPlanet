using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceList : MonoBehaviour
{
    public int priceForVeggie = 25;
    public int priceForEgg = 50;
    private static Dictionary<ValuebleItems, int> prices;

    private void Start()
    {
        FillPriceList();
      
    }
    enum ValuebleItems
    {
        Vegetable, 
        Egg
    }
    private void FillPriceList()
    {
        prices = new Dictionary<ValuebleItems, int>();
        prices.Add(ValuebleItems.Vegetable, priceForVeggie);
        prices.Add(ValuebleItems.Egg, priceForVeggie);
        
    }
    public static int GetPriceOf(GameObject item)
    {
        if (item.GetComponent<Vegetable>() != null)
        {
            return prices[ValuebleItems.Vegetable];
        }
        else if (item.GetComponent<Egg>() != null)
        {
            return prices[ValuebleItems.Egg];
        }
        else
        {
            throw new Exception("You cannot sell this item");
        } 
           
    }
}
