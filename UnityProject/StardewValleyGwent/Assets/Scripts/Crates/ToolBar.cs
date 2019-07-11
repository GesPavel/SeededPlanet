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
    public void TakeFromCrate(TransferItemScript rightHand)
    {
        rightHand.setItem(instrument);
        instrument = null;
    }
    public void Put(TransferItemScript rightHand)
    {
       instrument = rightHand.SendItem();
       rightHand.RemoveItem();
    }
    public void TakeOrPutItem(TransferItemScript rightHand)
    {
        if (rightHand.IsWithItem())
        {
            Put(rightHand);
        }
        else TakeFromCrate(rightHand);

    }
}

