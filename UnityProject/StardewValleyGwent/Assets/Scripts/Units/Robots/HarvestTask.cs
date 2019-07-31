using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestTask : AbstractTask
{
    protected override void AddToTaskListIfNecessary()
    {
        taskController.AddHarvestTask(this);
    }
    protected override void RemoveFromTaskListIfNecessary()
    {
        taskController.RemoveHarvestTask(this);
    }
    public override Type GetStrategyAccordingToType()
    {
        return typeof (HarvestRobotStategy);
    }
    protected override void DetermineDestination()
    {
        Destination = gameObject.transform;
    }
    private void OnDisable()
    {
        RemoveFromTaskListIfNecessary();
    }
}

