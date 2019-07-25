using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UniversalCrate : MonoBehaviour,ICrate
{
    public TextMeshPro seedIndicator;
    [SerializeField]private GameObject itemType;
    [SerializeField]private int itemsCounter = 0;

    private void Start()
    {
        seedIndicator.text = itemsCounter.ToString();
    }
    public void SetItem(GameObject item)
    {
        Destroy(item);
        itemsCounter++;
        seedIndicator.text = itemsCounter.ToString();
    }
    public GameObject SendItem()
    {
        if (itemsCounter == 0)
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
            SetItem(item);
            return null;
        }
        else
        {
            return SendItem();
        }
    }
}
