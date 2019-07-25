using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour,ICrate
{
    [SerializeField]private GameObject instrument;

    private void Start()
    {
        if (instrument != null) return;
        instrument = null;
    }
    private void Update()
    {
        if (instrument != null)
        {
            instrument.transform.position = transform.position;
        }
    }
    public GameObject ChangeItem(GameObject item)
    {
        var itemToSend = instrument;
        instrument = item;
        return itemToSend;
    }
}

