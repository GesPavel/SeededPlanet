using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour, Instrument
{
    PlayerController player;
    Ground standingGround;

    void Start()
    {

    }


    void Update()
    {

    }

    public void Use()
    {
        if (standingGround != null)
        {
                standingGround.Plow();
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
        if (collision.gameObject.tag == "Ground" && standingGround==collision.gameObject.GetComponent<Ground>())
        {
            standingGround = null;
        }
    }
}
