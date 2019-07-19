using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
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
    void Update()
    {
        AIPath aiPath = GetComponent<AIPath>();
        if (aiPath.canSearch == false && aiPath.canMove == false)
        {
            Move();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            aiPath.canMove = true;
            aiPath.canSearch = true;
        }
        if (Input.GetKey(KeyCode.X))
        {
            aiPath.canMove = false;
            aiPath.canSearch = false;
            Move();
        }

    }
}


