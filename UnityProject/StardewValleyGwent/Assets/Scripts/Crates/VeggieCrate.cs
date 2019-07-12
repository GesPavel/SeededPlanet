using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeggieCrate : MonoBehaviour, ICrate
{
    public Text label;
    public GameObject vegetable;
    public int veggieCounter = 0;
    void Start()
    {
        label.text = veggieCounter.ToString();
    }


    void Update()
    {

    }
    public void TakeOrPutItem(TransferItemScript leftHand)
    {
        if (leftHand.IsWithItem())
            Put(leftHand);
        else
            TakeFromCrate(leftHand);
    }
    public void TakeFromCrate(TransferItemScript leftHand)
    {
        if (veggieCounter > 0)
        {
            veggieCounter--;
            label.text = veggieCounter.ToString();
            leftHand.setItem(Instantiate(vegetable));
        }
    }
    public void Put(TransferItemScript leftHand)
    {
        GameObject veggie = leftHand.SendItem();
        if (vegetable.GetComponent<Vegetable>() != null)
        {
            Destroy(veggie);
            leftHand.RemoveItem();
            veggieCounter++;
            label.text = veggieCounter.ToString();
        }
    }
}
