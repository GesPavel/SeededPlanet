using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeggieCrate : MonoBehaviour
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
    public void TakeOrPutItem(HandScript hand)
    {
        if (hand.IsWithItem())
            Put(hand);
        else
            TakeFromCrate(hand);
    }
    public void TakeFromCrate(HandScript hand)
    {
        if (veggieCounter > 0)
        {
            veggieCounter--;
            label.text = veggieCounter.ToString();
            hand.setItem(Instantiate(vegetable));
        }
    }
    public void Put(HandScript hand)
    {
        GameObject veggie = hand.SendItem();
        if (veggie.GetComponent<Vegetable>() != null)
        {
            Destroy(veggie);
            hand.RemoveItem();
            veggieCounter++;
            label.text = veggieCounter.ToString();
        }
    }
}
