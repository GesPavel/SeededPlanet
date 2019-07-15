using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateredPlowed : BaseGround
{
    public float maxWaterVolume;
    public float waterCount=0;
    private PieceData pieceData;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<PieceData>().wateredPlowedSprite;
        pieceData = GetComponent<PieceData>();
    }

    void Update()
    {
        pieceData.currentWaterCount = waterCount;
        if (waterCount <= 0)
        {
            gameObject.AddComponent<UnWateredPlowed>();
            Destroy(this);
        }
        if (waterCount > 0)
        {
            waterCount -= Time.deltaTime;
        }
    }
}
