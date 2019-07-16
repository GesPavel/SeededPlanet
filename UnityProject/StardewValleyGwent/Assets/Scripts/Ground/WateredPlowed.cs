using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateredPlowed : BaseGround
{

    public float waterCount;
    public static Sprite wateredPlowedSprite;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = FindObjectOfType<SpriteVault>().wateredPlowedSprite;
    }

    public override void ChangeState()
    {
        gameObject.AddComponent<UnWateredPlowed>();
        FindObjectOfType<PlayerController>().currentGroundPosition = GetComponent<UnWateredPlowed>();
        Destroy(this);
    }
}
