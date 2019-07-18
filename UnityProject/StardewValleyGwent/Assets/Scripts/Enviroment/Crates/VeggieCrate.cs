using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VeggieCrate : MonoBehaviour
{
    public TextMeshPro indicator;
    public GameObject vegetable;
    public int veggieCounter = 0;
    private void Start()
    {
        if (vegetable != null)
        {
            indicator.text = veggieCounter.ToString();
            return;
        }
        vegetable = null;
        veggieCounter = 0;
        indicator.text = veggieCounter.ToString();
    }
    public void SetItem(GameObject item)
    {
        Destroy(item);
        veggieCounter++;
        indicator.text = veggieCounter.ToString();
    }
    public GameObject SendItem()
    {
        if (veggieCounter == 0)
        {
            return null;
        }
        veggieCounter--;
        indicator.text = veggieCounter.ToString();
        return Instantiate(vegetable, transform.position, Quaternion.identity);
    }
}
