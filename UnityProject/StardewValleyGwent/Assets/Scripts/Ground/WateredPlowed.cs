using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateredPlowed : BaseGround
{
    public float waterCount;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<PieceData>().wateredPlowedSprite;
    }

    void Update()
    {
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
