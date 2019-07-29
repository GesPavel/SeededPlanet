using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HarvestRobotStategy : RobotStrategy
{
    int vegetableLayerMask;
    RobotHarvester robot;
    private void Start()
    {
        vegetableLayerMask = LayerMask.GetMask("Default");
    }
    public override void Act()
    {
        robot = gameObject.GetComponent<RobotHarvester>();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.1f, vegetableLayerMask);
        HarvestTask harvestTask = hit.collider.gameObject.GetComponent<HarvestTask>();
        if (harvestTask != null)
        {
            robot.PickUpItem(harvestTask.gameObject);
            MoveToStorageTask newTask = harvestTask.gameObject.AddComponent<MoveToStorageTask>();
            newTask.SetItemType(harvestTask.gameObject);
            
            robot.SetTask(newTask);
            
        }
        harvestTask.SetComplete();
        Destroy(this);
    }
}