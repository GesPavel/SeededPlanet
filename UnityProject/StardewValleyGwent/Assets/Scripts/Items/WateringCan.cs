using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : Instrument
{
    public static float water;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void Use()
    {
        PlayerController player;
        GameObject standingGround;
        player = FindObjectOfType<PlayerController>();
        standingGround = player.GetCurrentGroundPosition();
        UnWateredPlowed ground = standingGround.GetComponent<UnWateredPlowed>();
        if (ground == null) return;
        ground.ChangeState();
        water -= 25;
        Debug.Log("количество воды в лейке: " + WateringCan.water);
    }

    public void FillUp()
    {
        water = 100;
        Debug.Log("Я заполнена на все "+water);
    }
}
