using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestTask : MonoBehaviour
{
    public Transform Destination { get; set; }
    bool inProgress = false;
    RobotTaskController taskController;

    private void Start()
    {
        taskController = FindObjectOfType<RobotTaskController>();
        taskController.AddHarvestTask(this);
        Destination = gameObject.transform;
    }
    public void ClaimTask()
    {
        inProgress = true;
        taskController.RemoveHarvestTask(this);
    }

    public void DropTask()
    {
        inProgress = false;
        taskController.AddHarvestTask(this);
    }

    public bool IsInProgress()
    {
        return inProgress;
    }


}

