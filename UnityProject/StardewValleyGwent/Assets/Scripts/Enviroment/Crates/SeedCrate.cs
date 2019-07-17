using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedCrate : MonoBehaviour
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
    public void TakeOrPutItem(HandScript hand)
    {
        if (hand.IsWithItem())
            Put(hand);
        else
            TakeFromCrate(hand);
    }
    public void TakeFromCrate(HandScript hand)
    {
        if (seedCounter > 0)
        {
            seedCounter--;
            label.text = seedCounter.ToString();
            hand.setItem(Instantiate(seed));
        }
    }
    public void Put(HandScript hand)
    {
        GameObject seed = hand.SendItem();
        if (seed.GetComponent<Seed>() != null)
        {
            Destroy(seed);
            hand.RemoveItem();
            seedCounter++;
            label.text = seedCounter.ToString();
        }
    }
}
