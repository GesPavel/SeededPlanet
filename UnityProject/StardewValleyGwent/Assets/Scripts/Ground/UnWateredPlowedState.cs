using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnWateredPlowedState : MonoBehaviour, GroundState
{
    public void ExecuteCommand(Ground ground)
    {
        Debug.Log("Земля не полита, но вспахана");
    }
}
