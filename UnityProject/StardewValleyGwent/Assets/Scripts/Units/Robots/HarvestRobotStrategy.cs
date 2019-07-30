using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HarvestRobotStategy : RobotStrategy
{
    int vegetableLayerMask;
    RobotHarvester robot;
    HarvestTask harvestTask;
    private void Start()
    {
        vegetableLayerMask = LayerMask.GetMask("Default");
        robot = gameObject.GetComponent<RobotHarvester>();
        robot.SetDistanceToPathComplete(0.1f);
    }
    public override void Act()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.1f, vegetableLayerMask);
        harvestTask = hit.collider.gameObject.GetComponent<HarvestTask>();
        if (harvestTask != null)
        {
            GatherVegetableAndStartNewTask();
        }
        ExitStrategy();
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
        robot.SetTask(newTask);
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