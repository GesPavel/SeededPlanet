using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour,IManufacturer
{
    [System.Serializable]
    public class Menu
    {
        public GameObject rawFood;
        public GameObject cookedFood;
    }

    public List<Menu> menu;

    private Dictionary<GameObject, GameObject> foodPairs;

    private void Start()
    {
        foodPairs = new Dictionary<GameObject, GameObject>();
        foreach(Menu menuItem in menu)
        {
            foodPairs.Add(menuItem.rawFood,menuItem.cookedFood);
        }
    }
    public GameObject Interact(GameObject food)
    {
        if(!foodPairs.ContainsKey(food))
        {
            return null;
        }
        return Instantiate(foodPairs[food]);
    }
}
