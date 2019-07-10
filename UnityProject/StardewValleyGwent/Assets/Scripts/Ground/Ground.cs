using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    bool IsOccupied { get; set; }
    GroundState currentState;

    public Ground()
    {
        this.currentState = new UnPlowedState();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
