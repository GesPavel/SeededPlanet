﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceList : MonoBehaviour
{
    [System.Serializable]
    public class PairProductAndPrice
    {
        public GameObject product;
        public int price;
    }

    public List<PairProductAndPrice> pairs;

    Dictionary<string, int> priceList;

    private void Start()
    {
        priceList = new Dictionary<string, int>();
        foreach(PairProductAndPrice pair in pairs)
        {
            IItem item = pair.product.GetComponent<IItem>();
            if (item == null) continue;
            if (item.ObjectsName == "") continue;
            priceList.Add(item.ObjectsName, pair.price);
        }
    }

    public int GetPriceOf(string itemsName)
    {
        if(!priceList.ContainsKey(itemsName))
        {
            throw new Exception("Not Founded");
        }
        return priceList[itemsName];
    }

}
