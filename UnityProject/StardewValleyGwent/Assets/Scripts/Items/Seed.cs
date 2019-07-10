using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, IUsable
{
    PlayerController Player;
    GameObject standingGround;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Use()
    {
        Player = FindObjectOfType<PlayerController>();
        Ground ground = standingGround.GetComponent<Ground>();
        if (ground != null)
        {
            PlantSeed(ground);
        }
        else
            Destroy(gameObject);
    }

    private void PlantSeed(Ground ground)
    {
        Debug.Log("Planted");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
