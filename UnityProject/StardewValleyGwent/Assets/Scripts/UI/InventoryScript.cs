using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private Transform slotHolder;
    [SerializeField] private Transform dragParent;
    [SerializeField] private InventorySlot slotTemplate;
    private List<InventorySlot> slots;
    #region Singleton
    public static InventoryScript instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion 
    private void Start()
    {
        slots = new List<InventorySlot>();
        gameObject.SetActive(false);
    }
    public bool TryPutItem(GameObject obj)
    {
        if (slots.Count < size)
        {
            var newSlot = Instantiate(slotTemplate);
            slots.Add(newSlot);
            newSlot.transform.SetParent(slotHolder);
            newSlot.InitTransforms(slotHolder, dragParent);
            newSlot.FillSlot(obj);
            return true;
        }
        return false;
    }
    public void AddSlot(InventorySlot slot)
    {
        slots.Add(slot);
    }
    public void RemoveSlot(InventorySlot slot)
    {
        slots.Remove(slot);
    }
    public bool HasEmptySlot()
    {
        if (slots.Count < size)
        {
            return true;
        }
        return false;
    }
}
