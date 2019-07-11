using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class GroundState : MonoBehaviour
{
   //void ExecuteCommand(Ground ground);
   // void HandleButton(Ground ground, PressedButton button);

   // void ChangeState(Ground ground, PressedButton button);




    internal virtual void HandleButton(Ground gameManager)
    {
        ChangeState(gameManager);
    }

    protected virtual void ChangeState(Ground gameManager)
    {
        Destroy(gameManager.gameObject.GetComponent<GroundState>());
    }
}

