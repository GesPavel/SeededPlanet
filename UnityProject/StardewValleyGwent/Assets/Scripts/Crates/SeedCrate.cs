using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedCrate : MonoBehaviour, ICrate
{
    public Text label;
    public GameObject seed;
    public int seedCounter = 0;
    void Start()
    {
        label.text = seedCounter.ToString();
    }

    
    void Update()
    {

    }
    public void TakeOrPutItem(TransferItemScript leftHand)
    {
        if (leftHand.IsWithItem())
            Put(leftHand);
        else
            TakeFromCrate(leftHand);
    }
    public void TakeFromCrate(TransferItemScript leftHand)
    {
        if (seedCounter > 0)
        {
            seedCounter--;
            label.text = seedCounter.ToString();
            leftHand.setItem(Instantiate(seed));
        }
    }
    public void Put(TransferItemScript leftHand)
    {
        GameObject seed = leftHand.SendItem();
        if (seed.GetComponent<Seed>() != null)
        {
            Destroy(seed);
            leftHand.RemoveItem();
            seedCounter++;
            label.text = seedCounter.ToString();
        }
    }
}
