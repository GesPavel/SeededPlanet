using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlowedState : MonoBehaviour, GroundState
{
    public virtual void ExecuteCommand(Ground ground)
    {
        Debug.Log("Земля вспахана");
    }
}
