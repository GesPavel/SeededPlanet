using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class WateredPlowedState : GroundState
{
    public Ground groundScript;
    float WaterDelay = 2;
    bool onUpdate;
    void Awake()
    {
        groundScript = GetComponent<Ground>();
    }
    internal WateredPlowedState()
    {
        onUpdate = true;
    }
    protected override void ChangeState(Ground gameManager)
    {

        base.ChangeState(gameManager);
        gameManager.gameObject.GetComponent<SpriteRenderer>().sprite = groundScript.unWatered;
        gameManager.State = gameObject.AddComponent<UnWateredPlowedState>();

    }
    public void Update()
    {
        if (onUpdate == true)
        {
            if (WaterDelay < 0)
            {
                
                //groundScript.State.HandleButton();
                WaterDelay = 2;
                onUpdate = false;
            }
            else if (WaterDelay > 0)
            {
                WaterDelay -= 0.1f;
                Debug.Log(WaterDelay);

            }
        }
    }


}
