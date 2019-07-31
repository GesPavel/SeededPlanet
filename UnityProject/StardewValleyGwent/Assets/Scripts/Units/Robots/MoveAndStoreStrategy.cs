using System;
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
        robot.SetDistanceToPathComplete(1.0f);
    }
    public override void Act()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, robot.GetDistanceToPathComplete() + 0.1f, crateLayerMask);
        if (hit.collider != null)
        {
            InteractWithTheCrate(hit.collider.gameObject);
        }
    }

    private void InteractWithTheCrate(GameObject crateGameObject)
    {
        UniversalCrate crate = crateGameObject.GetComponent<UniversalCrate>();
        if (crate.ItemIsValid(robot.itemInManipulator) || crate.IsEmpty())
        {
            robot.StoreItem(crate);
            ExitStrategy();
        }
        else
        {
            FailStrategy();
        }
    }

    private void FailStrategy()
    {
        robot.itemInManipulator.GetComponent<MoveToStorageTask>().FailTask();
        MoveToStorageTask task = robot.itemInManipulator.AddComponent<MoveToStorageTask>();
        robot.ReceiveTask(task);
        Destroy(this);
    }

    public override void ExitStrategy()
    {
        robot.SetFree();
        Destroy(this);
    }
}