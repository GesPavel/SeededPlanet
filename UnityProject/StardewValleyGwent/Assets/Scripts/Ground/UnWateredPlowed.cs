using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnWateredPlowed : BaseGround
{
    
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<PieceData>().unWateredPlowedSprite;
    }
    

    public override void UseItem()
    {
        gameObject.AddComponent<WateredPlowed>();
        gameObject.GetComponent<WateredPlowed>().maxWaterVolume = GetComponent<PieceData>().maxWaterValue;
        Destroy(this);
    }
}
