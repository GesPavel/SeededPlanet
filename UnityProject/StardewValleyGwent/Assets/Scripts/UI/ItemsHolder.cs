using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsHolder : MonoBehaviour
{
    public ItemAssets itemsList;
    public List<GameObject> prefabsList;
    public GameObject CreateItemByName(string name)
    {
        for(int i = 0; i < prefabsList.Count; i++)
        {
            IItem item = prefabsList[i].GetComponent<IItem>();
            if (item == null)
            {
                continue;
            }
            if (item.ObjectsName == name)
            {
                GameObject objectToGet = Instantiate(prefabsList[i]) as GameObject;
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
