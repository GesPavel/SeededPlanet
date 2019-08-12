using System;
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

    const int ITEM_NOT_FOUND_ERROR = -1;
    private void Start()
    {
        priceList = new Dictionary<string, int>();
        foreach (PairProductAndPrice pair in pairs)
        {
            IItem item = pair.product.GetComponent<IItem>();
            if (item == null) continue;
            if (item.ObjectsName == "") continue;
            priceList.Add(item.ObjectsName, pair.price);
        }
    }

    public int GetPriceOf(GameObject item)
    {
        IItem itemToTrade = item.GetComponent<IItem>();
        if (!priceList.ContainsKey(itemToTrade.ObjectsName))
        {
            return ITEM_NOT_FOUND_ERROR;
        }
        return priceList[itemToTrade.ObjectsName];
    }
}