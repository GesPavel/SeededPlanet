using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class UnPlowedState : GroundState
{


    internal UnPlowedState()
    {
        Debug.Log("Земля не вспахана");
    }

    protected override void ChangeState(Ground gameManager)
    {
        base.ChangeState(gameManager);
        gameManager.State = gameManager.gameObject.AddComponent<UnWateredPlowedState>();
    }

}
