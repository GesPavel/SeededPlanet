﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour, IConverter
{
    WateringCan can;

    public GameObject Convert(GameObject item)
    {
        if (item == null)
        {
            return null;
        }
        can = item.GetComponent<WateringCan>();
        if (can == null)
        {
            return item;
        }
        can.FillUp();
        return item;
    }
}
