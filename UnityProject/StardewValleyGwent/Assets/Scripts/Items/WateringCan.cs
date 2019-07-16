using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, Instrument
{
    public static float water = 0;
    public static float maxWaterVolume = 100;
    public static float waterPerUse = 25;
    PlayerController player;
    GameObject standingGround;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Use()
    {
        PlayerController player;
        GameObject standingGround;
        player = FindObjectOfType<PlayerController>();
        standingGround = player.GetCurrentGroundPosition();
        if (standingGround != null)
        {
            PlowedGroundInfo ground = standingGround.GetComponent<PlowedGroundInfo>();

            if (ground == null) return;
            if (water >= waterPerUse)
            {
                ground.AddWater(waterPerUse);
                water -= waterPerUse;
            }
        }
    }

    public void FillUp()
    {
        water = maxWaterVolume;
        
    }
}
