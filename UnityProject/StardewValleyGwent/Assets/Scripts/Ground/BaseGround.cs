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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>().currentGroundPosition==this)
        {
            collision.gameObject.GetComponent<PlayerController>().currentGroundPosition = null;
        }
    }
    public virtual void ChangeState()
    {

    }
}
