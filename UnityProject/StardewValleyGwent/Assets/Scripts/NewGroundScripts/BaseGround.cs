using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGround : MonoBehaviour
{
    
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().currentGroundPosition = this;
        }
    }
    public virtual void UseItem()
    {

    }
}
