using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductConverter : MonoBehaviour, IConverter
{
    [System.Serializable]
    public class InitialAndFinalProducts
    {
        public GameObject initialProduct;
        public GameObject finalProduct;
    }

    public List<InitialAndFinalProducts> initialAndFinalProducts;

    private Dictionary<string, GameObject> productPairs;
    Vector2 placeOnTheLeft; 
    Vector2 placeOnTheRight; 
    private void Start()
    {
        placeOnTheLeft = new Vector2(transform.position.x - 1, transform.position.y);
        placeOnTheRight = new Vector2(transform.position.x + 1, transform.position.y);
        productPairs = new Dictionary<string, GameObject>();
        foreach (InitialAndFinalProducts pair in initialAndFinalProducts)
        {
            IItem initialProduct = pair.initialProduct.GetComponent<IItem>();
            if (initialProduct == null) continue;
            if (initialProduct.ObjectsName == "") continue;
            productPairs.Add(initialProduct.ObjectsName, pair.finalProduct);
        }
    }
    public string RetrieveObjectsName(GameObject objectToConvert)
    {
        if (objectToConvert == null)
        {
            return null;
        }
        IItem productToConvert = objectToConvert.GetComponent<IItem>();
        if (productToConvert == null)
        {
            return null;
        }
        if (!productPairs.ContainsKey(productToConvert.ObjectsName))
        {
            return null;
        }
        return productToConvert.ObjectsName;
    }
    public GameObject Convert(GameObject objectToConvert)
    {
        string name = RetrieveObjectsName(objectToConvert);
        if (name == null)
        {
            return objectToConvert;
        }
        var finalProduct = Instantiate(productPairs[name]);
        Destroy(objectToConvert.gameObject);
        Instantiate(finalProduct, placeOnTheLeft, Quaternion.identity);
        Instantiate(finalProduct, placeOnTheRight, Quaternion.identity);
        return finalProduct;
    }
}
