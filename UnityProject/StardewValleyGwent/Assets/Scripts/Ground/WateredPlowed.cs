using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateredPlowed : BaseGround
{

    public float waterCount;
    GroundPieceData groundPieceData;
    public static Sprite wateredPlowedSprite;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<GroundPieceData>().wateredPlowedSprite;
        groundPieceData = GetComponent<GroundPieceData>();
    }

    public override void ChangeState()
    {
        gameObject.AddComponent<UnWateredPlowed>();
        FindObjectOfType<PlayerController>().currentGroundPosition = GetComponent<UnWateredPlowed>();
        Destroy(this);
    }
}
