using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceList : MonoBehaviour
{
    public int priceForVeggie = 25;
    public int priceForEgg = 50;
    private Dictionary<ValuebleItems, int> prices;

    private void Start()
    {
        float randomPriceMultiplier = UnityEngine.Random.Range(0.5f, 1.5f);
        FillPriceList(randomPriceMultiplier);
      
    }
    enum ValuebleItems
    {
        Vegetable, 
        Egg
    }
    private void FillPriceList(float randomPriceMultiplier)
    {
        prices = new Dictionary<ValuebleItems, int>();
        prices.Add(ValuebleItems.Vegetable,(int) (priceForVeggie * randomPriceMultiplier));
        prices.Add(ValuebleItems.Egg,(int) (priceForVeggie * randomPriceMultiplier));
        
    }
    public int GetPriceOf(GameObject item)
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
            throw new Exception("Я такое не куплю!");
        } 
           
    }
}
