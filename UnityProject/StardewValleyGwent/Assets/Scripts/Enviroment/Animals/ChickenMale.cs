using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class ChickenMale : Animal
{
    ChickenGirl girlfriend;
    
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
        if (hasReachedDestination)
        {
            AIPath aiPath = GetComponent<AIPath>();
            if (aiPath.canSearch == false && aiPath.canMove == false)
            {

                MoveRandomly();
                OnRayCollision();
            }
            if (timeToSex > 0)
            {
                if (HasGirlFriend())
                {
                    aiPath.canMove = true;
                    aiPath.canSearch = true;
                }
                else
                {
                    FindGirlFriend();
                }
            }
            else if (timeToSex <= 0)
            {
                aiPath.canMove = false;
                aiPath.canSearch = false;
                timeToSex += Time.deltaTime;
            }
        }
        else
        {
            CheckIfAnimalGatheringPointReached();
        }
    }

    private bool HasGirlFriend()
    {
        return girlfriend != null;
    }
    protected override void CheckIfAnimalGatheringPointReached()
    {
        if (aIPath.reachedDestination)
        {
            aIPath.canMove = false;
            aIPath.canSearch = false;
            hasReachedDestination = true;
            FindGirlFriend();
        }
    }

    private void FindGirlFriend()
    {
        ChickenGirl[] hens = FindObjectsOfType<ChickenGirl>();
        foreach (ChickenGirl girl in hens)
        {
            if (!girl.HasBoyFriend())
            {
                girlfriend = girl;
                girl.boyfriend = this;
                
                break;
            }
        }
        if (!HasGirlFriend())
        {
            timeToSex = -60;
        }
    }
}


