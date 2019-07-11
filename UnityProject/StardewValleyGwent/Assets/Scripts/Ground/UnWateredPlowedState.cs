﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class UnWateredPlowedState : GroundState
{

    public Ground groundScript;
    void Awake()
    {
        groundScript = GetComponent<Ground>();
    }

    internal UnWateredPlowedState()
    {
       
        Debug.Log("Земля вспахана, но не полита");
    }

    protected override void ChangeState(Ground gameManager)
    {
        base.ChangeState(gameManager);
        gameManager.gameObject.GetComponent<SpriteRenderer>().sprite = groundScript.sprites[1];
        gameManager.State = gameObject.AddComponent<WateredPlowedState>();
    }
}
