using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour, IConvertor
{
    WateringCan can;

    public GameObject Convert(GameObject item)
    {
        can = item.GetComponent<WateringCan>();
        if (can == null)
        {
            return item;
        }
        can.FillUp();
        return item;
    }
}
