using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedCrate : MonoBehaviour, ICrate
{
    public Text label;
    int seedCounter = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
    }
    public void TakeFrom()
    {
        seedCounter--;
        label.text = seedCounter.ToString();
    }
    public void Put()
    {
        seedCounter++;
        label.text = seedCounter.ToString();
    }
}
