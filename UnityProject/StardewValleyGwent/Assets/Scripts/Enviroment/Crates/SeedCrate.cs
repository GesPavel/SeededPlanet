using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedCrate : MonoBehaviour
{
    public TextMeshPro seedIndicator;
    [SerializeField]private GameObject seed;
    public int seedCounter = 0;
    private void Start()
    {
        if (seed != null)
        {
            seedIndicator.text = seedCounter.ToString();
            return;
        }
        seed = null;
        seedCounter = 0;
        seedIndicator.text = seedCounter.ToString();
    }
    public void SetItem(GameObject item)
    {
        Destroy(item);
        seedCounter++;
        seedIndicator.text = seedCounter.ToString();
    }
    public GameObject SendItem()
    {
        if (seedCounter == 0)
        {
            return null;
        }
        seedCounter--;
        seedIndicator.text = seedCounter.ToString();
        return Instantiate(seed, transform.position, Quaternion.identity);
    }
}
