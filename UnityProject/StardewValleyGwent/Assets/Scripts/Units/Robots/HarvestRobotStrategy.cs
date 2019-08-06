using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HarvestRobotStategy : RobotStrategy
{
    RobotHarvester robot;
    HarvestTask harvestTask;
    LayerMask vegetableLayerMask;
    private void Start()
    {
        vegetableLayerMask = LayerMask.GetMask("Items");
        robot = gameObject.GetComponent<RobotHarvester>();
        robot.SetDistanceToPathComplete(0.1f);
    }
    public override void Act()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.1f, vegetableLayerMask);
        if (hit.collider != null && hit.collider.gameObject.GetComponent<HarvestTask>() != null)
        {
            harvestTask = hit.collider.gameObject.GetComponent<HarvestTask>();
            GatherVegetableAndStartNewTask();
            ExitStrategy();
        }
        else
        {
            FailStrategy();
        }
    }

    private void FailStrategy()
    {
        robot.SetFree();

        Destroy(this);
    }

    private void GatherVegetableAndStartNewTask()
    {
        GatherVegetable();

        StartNewTask();
    }

    private void StartNewTask()
    {
        MoveToStorageTask newTask = harvestTask.gameObject.AddComponent<MoveToStorageTask>();
        newTask.SetItemType(harvestTask.gameObject);
        robot.ReceiveTask(newTask);
    }

    private void GatherVegetable()
    {
        robot.PickUpItem(harvestTask.gameObject);
    }
    public override void ExitStrategy()
    {
        harvestTask.SetComplete();
        Destroy(this);
    }
}