using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    Ground ground;
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HandScript playerHand = collision.gameObject.GetComponent<PlayerController>().rightHand.GetComponent<HandScript>();
            if (!playerHand.IsWithItem())
            {
                playerHand.setItem(this.gameObject);
                //FindObjectOfType<PlayerController>().currentGroundPosition.gameObject.GetComponent<GroundPieceData>().isOccupied = false;
                ground.isOccupied = false;
                ground = null;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
     
    }
    public void SetPieceGround(Ground ground)
    {
        this.ground = ground;
        return;
    }
}
