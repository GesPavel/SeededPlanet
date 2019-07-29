using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveAndStoreStrategy : RobotStrategy
{
    int crateLayerMask;
    RobotHarvester robot;
    private void Start()
    {
        crateLayerMask = LayerMask.GetMask("BlockingLayer");
        robot = gameObject.GetComponent<RobotHarvester>();
        robot.SetDistanceToPathComplete(1.5f);
    }
    public override void Act()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, robot.GetDistanceToPathComplete() - 0.1f, crateLayerMask);
        UniversalCrate crate = hit.collider.gameObject.GetComponent<UniversalCrate>();
        robot.StoreItem(crate);
        FindObjectOfType<RobotTaskController>().DeclareFree(robot);    
    }
}