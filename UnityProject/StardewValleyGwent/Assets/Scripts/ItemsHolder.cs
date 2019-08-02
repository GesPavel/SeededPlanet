using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsHolder : MonoBehaviour
{
    public ItemAssets itemsList;

    public GameObject GetItemByName(string name)//??
    {
        for(int i = 0; i < itemsList.prefabsList.Count; i++)
        {
            IItem item = itemsList.prefabsList[i].GetComponent<IItem>();
            if (item == null)
            {
                continue;
            }
            if (item.ObjectsName == name)
            {
                var objectToGet = Instantiate(itemsList.prefabsList[i]);
                return objectToGet;
            }
        }
        return null;
    }

    #region Singleton
    public static ItemsHolder instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
}
