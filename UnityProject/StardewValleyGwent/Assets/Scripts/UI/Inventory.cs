using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventorySlot[] slots;
    public InventorySlot activeItemSlot;

    public bool TrySetItem(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].IsFull)
            {
                slots[i].Set(item);
                return true;
            }
        }
        return false;
    }
}
