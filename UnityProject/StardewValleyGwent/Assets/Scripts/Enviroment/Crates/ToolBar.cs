using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    [SerializeField]private GameObject instrument;

    private void Start()
    {
        if (instrument != null) return;
        instrument = null;
    }
    public void SetItem(GameObject item)
    {
        instrument = item;
    }
    public GameObject SendItem()
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

