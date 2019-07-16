using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnWateredPlowed : BaseGround
{

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = FindObjectOfType<SpriteVault>().unWateredPlowedSprite;
    }


    public override void ChangeState()
    {
        gameObject.AddComponent<WateredPlowed>();
        FindObjectOfType<PlayerController>().currentGroundPosition = GetComponent<WateredPlowed>();
        gameObject.GetComponent<WateredPlowed>().waterCount =
                           gameObject.GetComponent<PlowedGroundInfo>().currentWaterCount;
        Destroy(this);
    }
}

