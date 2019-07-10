using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    bool IsOccupied { get; set; }
    GroundState currentState;




    // Start is called before the first frame update
    void Start()
    {
        
        currentState = gameObject.AddComponent<WateredPlowedState>();
        currentState.ExecuteCommand(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
