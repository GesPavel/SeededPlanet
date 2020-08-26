using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGirl : Animal
{
    public GameObject egg;
    public ChickenMale boyfriend;
    bool outOfEggs = false; 
    float timeToSex = -1; 
    public override void OnCollisionEnter2D(Collision2D coll)
    {
        base.OnCollisionEnter2D(coll);
        
        if (!outOfEggs && hasReachedDestination)
        {
            if (coll.gameObject.tag == "ChickenMale")
            {

                    GameObject thisEgg = Instantiate(egg, transform.position, Quaternion.identity);
                    ChangeDirection();
                    outOfEggs = true;
                   
            }
        }
    }
    public override void Update()
    {
        base.Update();
        if (outOfEggs)
        {
            timeToSex += Time.deltaTime * Time.timeScale;
            if (timeToSex > 0)
            {
                outOfEggs = false;
                timeToSex = -5;
            }
        }
    }

    public bool HasBoyFriend()
    {
        return boyfriend != null;
    }
}
