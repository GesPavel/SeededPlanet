using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class WateredPlowedState : GroundState
{
    public Ground groundScript;

    void Awake()
    {
        groundScript = GetComponent<Ground>();
    }
    internal WateredPlowedState()
    {
        Debug.Log("Земля полита и вспахана");
        
    }
    protected override void ChangeState(Ground gameManager)
    {

        base.ChangeState(gameManager);
        gameManager.gameObject.GetComponent<SpriteRenderer>().sprite = groundScript.sprites[0];
        gameManager.State = gameObject.AddComponent<UnWateredPlowedState>();

    }

}
