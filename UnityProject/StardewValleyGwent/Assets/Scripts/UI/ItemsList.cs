using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemsList")]
[System.Serializable]
public class ItemAssets : ScriptableObject
{
    public List<GameObject> prefabsList;    
}
