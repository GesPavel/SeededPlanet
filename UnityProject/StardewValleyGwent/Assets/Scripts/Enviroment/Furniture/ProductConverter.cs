using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductConverter : MonoBehaviour, IConverter
{
    [System.Serializable]
    public class InitialandFinalProducts
    {
        public GameObject initialProduct;
        public GameObject finalProduct;
    }

    public List<InitialandFinalProducts> initialAndFinalProducts;

    private Dictionary<string, GameObject> productPairs;

    private void Start()
    {
        productPairs = new Dictionary<string, GameObject>();
        foreach(InitialandFinalProducts pair in initialAndFinalProducts)
        {
            IItem initialProduct = pair.initialProduct.GetComponent<IItem>();
            if (initialProduct == null) continue;
            if (initialProduct.ObjectsName == "") continue;
            productPairs.Add(initialProduct.ObjectsName,pair.finalProduct);
        }
    }
    public GameObject Convert(GameObject objectToConvert)
    {
        if (objectToConvert == null) return objectToConvert;
        IItem productToConvert = objectToConvert.GetComponent<IItem>();
        if (productToConvert == null) return objectToConvert;
        if(!productPairs.ContainsKey(productToConvert.ObjectsName))
        {
            return objectToConvert;
        }
        var finalProduct = Instantiate(productPairs[productToConvert.ObjectsName]);
        Destroy(objectToConvert.gameObject);
        return finalProduct;
    }
}
