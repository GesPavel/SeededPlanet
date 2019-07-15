using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour, ICrate
{
    public GameObject instrument;


    void Start()
    {

    }


    void Update()
    {
        if (instrument != null) instrument.transform.position = transform.position;
    }
    public void TakeFromCrate(HandScript hand)
    {
        hand.setItem(instrument);
        instrument = null;
    }
    public void Put(HandScript hand)
    {
        GameObject handItem = hand.SendItem();
        if (handItem.GetComponent(typeof(Instrument)) != null)
        {
            if (instrument != null)
            {
                hand.setItem(instrument);
            }
            else
                hand.RemoveItem();
            instrument = handItem;
        }
    }
    public void TakeOrPutItem(HandScript hand)
    {
        if (hand.IsWithItem())
        {
            Put(hand);
        }
        else TakeFromCrate(hand);

    }
}

