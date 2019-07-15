using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnWateredPlowed : BaseGround
{

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<GroundPieceData>().unWateredPlowedSprite;
    }


    public override void ChangeState()
    {
        gameObject.AddComponent<WateredPlowed>();
        FindObjectOfType<PlayerController>().currentGroundPosition = GetComponent<WateredPlowed>();
        gameObject.GetComponent<WateredPlowed>().waterCount =
                           gameObject.GetComponent<GroundPieceData>().currentWaterCount;
        Destroy(this);
    }
}

