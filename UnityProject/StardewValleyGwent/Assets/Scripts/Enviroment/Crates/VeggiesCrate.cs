using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VeggiesCrate : MonoBehaviour
{
    public TextMeshPro vegetableIndicator;
    public GameObject vegetable;
    public int veggiesCounter = 0;
    private void Start()
    {
        if (vegetable != null)
        {
            vegetableIndicator.text = veggiesCounter.ToString();
            return;
        }
        vegetable = null;
        veggiesCounter = 0;
        vegetableIndicator.text = veggiesCounter.ToString();
    }
    public void SetItem(GameObject item)
    {
        Destroy(item);
        veggiesCounter++;
        vegetableIndicator.text = veggiesCounter.ToString();
    }
    public GameObject SendItem()
    {
        if (veggiesCounter == 0)
        {
            return null;
        }
        veggiesCounter--;
        vegetableIndicator.text = veggiesCounter.ToString();
        return Instantiate(vegetable, transform.position, Quaternion.identity);
    }
}
