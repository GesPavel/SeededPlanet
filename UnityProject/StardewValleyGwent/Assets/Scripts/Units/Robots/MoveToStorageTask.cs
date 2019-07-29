
using System;
using UnityEngine;

public class MoveToStorageTask : AbstractTask
{
    GameObject itemToStore;
    protected override void AddToTaskListIfNecessary()
    {
        
    }
    protected override void RemoveFromTaskListIfNecessary()
    {

    }

    public override Type GetStrategyAccordingToType()
    {
        return typeof(MoveAndStoreStrategy);
    }
    protected override void DetermineDestination()
    {
        UniversalCrate[] crates =  FindObjectsOfType<UniversalCrate>();
        for (int i = 0; i< crates.Length; i++)
        {
            if (crates[i].ItemIsValid(itemToStore))
            {
                Destination = crates[i].transform;
                return;
            }
        }
        for (int i = 0; i < crates.Length; i++)
        {
            if (crates[i].itemType == null)
            {
                Destination = crates[i].transform;
                return;
            }
        }

    }

    internal void SetItemType(GameObject item)
    {
        itemToStore = item;
    }
}