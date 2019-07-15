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
            if (ground != null && (ground is WateredPlowed || ground is UnWateredPlowed))
            {
                PlantSeed(ground as BaseGround);
            }
            else
                Destroy(gameObject);
        }
    }

    private void PlantSeed(BaseGround ground)
    {

        GameObject sapling = Instantiate(plant, ground.transform.position, Quaternion.identity);
        //sapling.SetBaseGround(ground);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
