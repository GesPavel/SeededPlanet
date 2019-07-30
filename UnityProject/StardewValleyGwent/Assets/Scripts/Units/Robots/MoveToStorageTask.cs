
using System;
using UnityEngine;

public class MoveToStorageTask : AbstractTask
{
    GameObject itemToStore;
    protected override void AddToTaskListIfNecessary()
    {
        return;
    }
    protected override void RemoveFromTaskListIfNecessary()
    {
        return;
    }

    public override Type GetStrategyAccordingToType()
    {
        return typeof(MoveAndStoreStrategy);
    }
    protected override void DetermineDestination()
    {
        itemToStore = gameObject;
        UniversalCrate[] crates =  FindObjectsOfType<UniversalCrate>();
        Destination = TryToFindCratesWithValidItems(crates);
        if (Destination == null)
        {
            Destination = TryToFindEmptyCrates(crates);
        }
        if (Destination == null)
        {
            Debug.Log("Нет свободных ящиков");
        }
    }

    private Transform TryToFindEmptyCrates(UniversalCrate[] crates)
    {
        for (int i = 0; i < crates.Length; i++)
        {
            if (crates[i].crateItem == null)
            {
                return crates[i].transform;
            }
        }
        return null;
    }

    private Transform TryToFindCratesWithValidItems(UniversalCrate[] crates)
    {
        for (int i = 0; i < crates.Length; i++)
        {
            if (crates[i].ItemIsValid(itemToStore))
            {
                return crates[i].transform;
            }
        }
        return null;
    }

    internal void SetItemType(GameObject item)
    {
        itemToStore = item;
    }
}