using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateredState : PlowedState
{
    public override void ExecuteCommand(Ground ground)
    {
        Debug.Log("Земля полита и вспахана");
    }
}
