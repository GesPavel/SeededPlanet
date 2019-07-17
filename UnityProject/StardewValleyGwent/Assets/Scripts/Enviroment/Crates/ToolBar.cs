using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    public GameObject instrument;
    
    public void SetItem(GameObject item)
    {
        instrument = item;
    }
    public GameObject GetItem()
    {
        return instrument;
    }
    private void Update()
    {
        if (instrument != null)
        {
            instrument.transform.position = transform.position;
        }
    }
}

