using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnWateredPlowed : BaseGround
{
    public float waterCount=25;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<PieceData>().unWateredPlowedSprite;
    }
    

    public override void ChangeState()
    {
        if (WateringCan.water <= 0) { }
        else
        {
            gameObject.AddComponent<WateredPlowed>();           
            gameObject.GetComponent<WateredPlowed>().waterCount = waterCount;
            Destroy(this);
        }
    }
}
