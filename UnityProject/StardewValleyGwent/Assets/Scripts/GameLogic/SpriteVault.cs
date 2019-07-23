using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteVault : MonoBehaviour
{
    [Tooltip("Спрайты земли")] 
    public Sprite DryRawSprite;
    public Sprite WetRawSprite;
    public Sprite WetPlowedSprite;
    public Sprite DryPlowedSprite;
    [Tooltip("Спрайты абстрактного растения")]
    public Sprite sproutStateSprite;
    public Sprite saplingStateSprite;
    public Sprite biggerSaplingStateSprite;
    public Sprite grownStateSplrite;
    [Tooltip("Спрайты растения котика")]
    public Sprite sproutStateSpriteCat;
    public Sprite saplingStateSpriteCat;
    public Sprite biggerSaplingStateSpriteCat;
    public Sprite grownStateSplriteCat;
}
