using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class UniversalCrate : MonoBehaviour, ICrate
{
    public TextMeshPro seedIndicator;
    public GameObject itemType;
    [SerializeField] private int itemsCounter = 0;

    private void Start()
    {
        seedIndicator.text = itemsCounter.ToString();
        itemType = null;
    }
    public void PutItem(GameObject item)
    {
        if (itemType == null)
        {
            itemType = Instantiate(item);
        }
        if (ItemIsValid(item))
        {
            Destroy(item);
            itemsCounter++;
            seedIndicator.text = itemsCounter.ToString();
        }
    }

    public bool ItemIsValid(GameObject item)
    {
        if (itemType != null)
        {
            IItem itemInterface = item.GetComponent<IItem>();
            IItem itemInCrateInterface = itemType.GetComponent<IItem>();
            return itemInterface.ObjectsName == itemInCrateInterface.ObjectsName;
        }
        return false;
    }

    public GameObject SendItem()
    {
        if (itemsCounter == 0 || itemType == null)
        {
            return null;
        }
        itemsCounter--;
        seedIndicator.text = itemsCounter.ToString();
        return Instantiate(itemType, transform.position, Quaternion.identity);
    }

    public GameObject ChangeItem(GameObject item)
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
}
