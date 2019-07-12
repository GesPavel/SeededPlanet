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
        BaseGround ground = standingGround.GetComponent<BaseGround>();
        if (ground != null)
        {
            PlantSeed(ground);
        }
        else
            Destroy(gameObject);
    }

    private void PlantSeed(BaseGround ground)
    {
        Debug.Log("Planted");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
