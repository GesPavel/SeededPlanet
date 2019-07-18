using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeggieCrate : MonoBehaviour
{
    public Text label;
    public GameObject vegetable;
    public int veggieCounter = 0;
    private void Start()
    {
        if (vegetable != null)
        {
            label.text = veggieCounter.ToString();
            return;
        }
        vegetable = null;
        veggieCounter = 0;
        label.text = veggieCounter.ToString();
    }
    public void SetItem(GameObject item)
    {
        Destroy(item);
        veggieCounter++;
        label.text = veggieCounter.ToString();
    }
    public GameObject SendItem()
    {
        if (veggieCounter == 0)
        {
            return null;
        }
        veggieCounter--;
        label.text = veggieCounter.ToString();
        return Instantiate(vegetable, transform.position, Quaternion.identity);
    }
}
