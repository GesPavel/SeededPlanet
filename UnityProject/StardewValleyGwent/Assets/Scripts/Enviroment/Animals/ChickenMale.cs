using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class ChickenMale : Animal
{
   
    float timeToSex = 1;
    public override void OnCollisionEnter2D(Collision2D coll)
    {
        base.OnCollisionEnter2D(coll);
        if (coll.gameObject.tag == "ChickenGirl")
        {
                timeToSex = -60;
        }
     }
    public override void Update()
    {
        
        AIPath aiPath = GetComponent<AIPath>();
        if (aiPath.canSearch == false && aiPath.canMove == false)
        {
            transform.up = direction;
            Move();
        }
        if (timeToSex>0) 
        {
            aiPath.canMove = true;
            aiPath.canSearch = true;
            
        }
        if (timeToSex<=0) 
        {
            aiPath.canMove = false;
            aiPath.canSearch = false;
            timeToSex += Time.deltaTime;
        }

    }
}


