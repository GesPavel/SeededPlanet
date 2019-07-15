using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnWateredPlowed : BaseGround
{

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<PieceData>().unWateredPlowedSprite;
    }


    public override void UseItem(GameObject item)
    {
        if (item.GetComponent<WateringCan>())
        {
            gameObject.AddComponent<WateredPlowed>();
            gameObject.GetComponent<WateredPlowed>().waterCount = 3;
            Destroy(this);
        }
    }
}
