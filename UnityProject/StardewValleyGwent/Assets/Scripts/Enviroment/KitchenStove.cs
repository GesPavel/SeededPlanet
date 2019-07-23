using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenStove : MonoBehaviour,IManufacturer
{
    [System.Serializable]
    public class RawAndCookedFood
    {
        public GameObject rawFood;
        public GameObject cookedFood;
    }

    public List<RawAndCookedFood> rawAndCookedFood;

    private Dictionary<string, GameObject> foodPairs;

    private void Start()
    {
        foodPairs = new Dictionary<string, GameObject>();
        foreach(RawAndCookedFood pair in rawAndCookedFood)
        {
            IItem rawFood = pair.rawFood.GetComponent<IItem>();
            if (rawFood == null) continue;
            if (rawFood.ObjectsName == "") continue;
            foodPairs.Add(rawFood.ObjectsName,pair.cookedFood);
        }
    }
    public GameObject Interact(GameObject objectToCook)
    {
        if (objectToCook == null) return objectToCook;
        IItem foodToCook = objectToCook.GetComponent<IItem>();
        if (foodToCook == null) return objectToCook;
        if(!foodPairs.ContainsKey(foodToCook.ObjectsName))
        {
            return objectToCook;
        }
        var cookedFood = Instantiate(foodPairs[foodToCook.ObjectsName]);
        Destroy(objectToCook.gameObject);
        return cookedFood;
    }
}
