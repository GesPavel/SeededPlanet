using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnWateredState : PlowedState
{
    public override void ExecuteCommand(Ground ground)
    {
        Debug.Log("Земля не полита, но вспахана");
    }
}
