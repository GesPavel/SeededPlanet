using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    [SerializeField]private GameObject inst;

    private void Start()
    {
        if (inst != null) return;
        inst = null;
    }
    public void SetItem(GameObject item)
    {
        inst = item;
    }
    public GameObject GetItem()
    {
        return inst;
    }
    private void Update()
    {
        if (inst != null)
        {
            inst.transform.position = transform.position;
        }
    }
}

