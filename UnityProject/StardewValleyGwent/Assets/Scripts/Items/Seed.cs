using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, IUsable
{
    PlayerController player;
    GameObject standingGround;
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
            var ground = standingGround.GetComponent(typeof(BaseGround));
            if (ground.gameObject.GetComponent<PlowedGroundInfo>().isOccupied) return;
            if (ground != null && (ground is WateredPlowed || ground is UnWateredPlowed))
            {
                PlantSeed(ground as BaseGround);
            }
            else
            {
                player.gameObject.transform.GetChild(1).GetComponent<HandScript>().setItem(null);
                Destroy(gameObject);
            }

        }
    }

    private void PlantSeed(BaseGround ground)
    {

        GameObject sapling = Instantiate(plant, ground.transform.position, Quaternion.identity);
        sapling.GetComponent<Plant1>().SetBaseGround(ground);
        ground.gameObject.GetComponent<PlowedGroundInfo>().isOccupied = true;
        player.gameObject.transform.GetChild(1).GetComponent<HandScript>().setItem(null);
        Destroy(gameObject);
        

    }

   
}
