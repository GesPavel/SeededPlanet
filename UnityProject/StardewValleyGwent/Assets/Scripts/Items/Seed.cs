using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    PlayerController player;
    public Ground StandingGround { get; private set; }
    public GameObject plant;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            StandingGround = collision.gameObject.GetComponent<Ground>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && StandingGround == collision.gameObject.GetComponent<Ground>())
        {
            StandingGround = null;
        }
    }
}