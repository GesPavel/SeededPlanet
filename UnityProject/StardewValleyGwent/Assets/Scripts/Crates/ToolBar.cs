using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour, ICrate
{
    public GameObject instrument;
    GameObject playersHand;
    void Start()
    {

    }


    void Update()
    {
        if (instrument != null) instrument.transform.position = transform.position;
    }
    public void TakeFrom()
    {
        playersHand.GetComponent<TransferItemScript>().setItem(instrument);
        instrument = null;
    }
    public void Put()
    {
       instrument = playersHand.GetComponent<TransferItemScript>().SendItem();
       playersHand.GetComponent<TransferItemScript>().RemoveItem();
    }
    public void TakeOrPutItem(GameObject rightHand)
    {
       
        playersHand = rightHand;
        if (playersHand.GetComponent<TransferItemScript>().IsWithItem())
        {
            Put();
            playersHand = null;
        }
        else TakeFrom();

    }
}

