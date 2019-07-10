using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateredPlowedState : MonoBehaviour, GroundState
{
    public void ExecuteCommand(Ground ground)
    {
        Debug.Log("Земля полита и вспахана");
    }
}
