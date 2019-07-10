using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPlowedState : MonoBehaviour, GroundState
{
    public void ExecuteCommand(Ground ground)
    {
        Debug.Log("Земля не вспахана");
    }
}
