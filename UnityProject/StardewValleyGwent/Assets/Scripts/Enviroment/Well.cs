using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    WateringCan can;
    void Start()
    {

    }


    void Update()
    {

    }

    public void Interact(HandScript hand)
    {
        
        if (hand.IsWithItem())

            can = hand.SendItem().GetComponent<WateringCan>();
        if (can != null)
            can.FillUp();

    }
}
