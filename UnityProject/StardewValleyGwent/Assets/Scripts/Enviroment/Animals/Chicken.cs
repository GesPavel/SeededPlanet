using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ChickenGirl")
        {
                speed = Random.Range(0.5f, 2);
                direction.x = direction.x * (-1) * Mathf.Sin(Random.Range(2 * Mathf.PI / 3, 4 * Mathf.PI / 3));
                direction.y = direction.y * (-1) * Mathf.Sin(Random.Range(2 * Mathf.PI / 3, 4 * Mathf.PI / 3));
                timeForStop = Random.Range(-1, -5);
         }
     }
}


