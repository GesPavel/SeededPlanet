using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, IUsable
{
    PlayerController player;
    Ground standingGround;
    public GameObject plant;

    public void Use()
    {
        if (standingGround != null)
        {
            standingGround.AddPlant(plant);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            standingGround = collision.gameObject.GetComponent<Ground>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && standingGround == collision.gameObject.GetComponent<Ground>())
        {
            standingGround = null;
            Debug.Log(555);
        }
    }
}