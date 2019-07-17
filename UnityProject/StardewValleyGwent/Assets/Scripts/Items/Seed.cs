using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, IUsable
{
    PlayerController player;
    Ground standingGround;
    public GameObject plant;

    void Start()
    {

    }

    void Update()
    {

    }
    public void Use()
    {
        player = FindObjectOfType<PlayerController>();
        standingGround = player.GetCurrentGroundPosition();
        if (standingGround != null)
        {
            standingGround.AddPlant(plant);
            player.gameObject.transform.GetChild(1).GetComponent<HandScript>().setItem(null);
            Destroy(gameObject);
        }

    }
}