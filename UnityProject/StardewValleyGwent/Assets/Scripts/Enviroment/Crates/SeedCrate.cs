using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedCrate : MonoBehaviour
{
    public Text label;
    [SerializeField]private GameObject seed;
    public int seedCounter = 0;
    private void Start()
    {
        if (seed != null)
        {
            label.text = seedCounter.ToString();
            return;
        }
        seed = null;
        seedCounter = 0;
        label.text = seedCounter.ToString();
    }
    public void SetItem(GameObject item)
    {
        Destroy(item);
        seedCounter++;
        label.text = seedCounter.ToString();
    }
    public GameObject SendItem()
    {
        if (seedCounter == 0)
        {
            return null;
        }
        seedCounter--;
        label.text = seedCounter.ToString();
        return Instantiate(seed, transform.position, Quaternion.identity);
    }
}
