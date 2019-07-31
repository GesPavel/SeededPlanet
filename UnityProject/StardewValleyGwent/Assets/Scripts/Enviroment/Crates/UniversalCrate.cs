using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class UniversalCrate : MonoBehaviour, ICrate
{
    public TextMeshPro seedIndicator;
    public GameObject crateItem;
    [SerializeField] private int itemsCounter = 0;

    private void Start()
    {
        seedIndicator.text = itemsCounter.ToString();
        crateItem = null;
    }
    public GameObject TradeItem(GameObject item)
    {

        if (item != null)
        {
            PutItem(item);
            return null;
        }
        else
        {
            return SendItem();
        }
    }
    public void PutItem(GameObject item)
    {
        if (crateItem == null)
        {
            SetCrateItem(item);
        }
        if (ItemIsValid(item))
        {
            Destroy(item);
            itemsCounter++;
            seedIndicator.text = itemsCounter.ToString();
        }
    }

    private void SetCrateItem(GameObject item)
    {
        GameObject itemToStore = Instantiate(item);
        if (itemToStore.GetComponent<BoxCollider2D>())
        {
            itemToStore.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (itemToStore.GetComponent<CircleCollider2D>())
        {
            itemToStore.GetComponent<CircleCollider2D>().enabled = false;
        }
        itemToStore.transform.position = gameObject.transform.position;
        itemToStore.transform.rotation = Quaternion.identity;
        crateItem = itemToStore;
    }

    public bool ItemIsValid(GameObject item)
    {
        if (crateItem != null)
        {
            IItem itemInterface = item.GetComponent<IItem>();
            IItem itemInCrateInterface = crateItem.GetComponent<IItem>();
            return itemInterface.ObjectsName == itemInCrateInterface.ObjectsName;
        }
        return false;
    }

    public GameObject SendItem()
    {
        if (itemsCounter == 0 || crateItem == null)
        {
            return null;
        }
        itemsCounter--;
        seedIndicator.text = itemsCounter.ToString();
        GameObject itemToGive = Instantiate(crateItem);
        if (itemToGive.GetComponent<BoxCollider2D>() != null)
        {
            itemToGive.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (itemToGive.GetComponent<CircleCollider2D>() != null)
        {
            itemToGive.GetComponent<CircleCollider2D>().enabled = true;
        }
        if (itemsCounter == 0)
        {
            ClearCrate();
        }
        return itemToGive;
    }

    private void ClearCrate()
    {
        Destroy(crateItem);
        crateItem = null;
    }

    public bool IsEmpty()
    {
        return crateItem == null;
    }
}
