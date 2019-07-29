using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class RobotHarvester : MonoBehaviour
{
    AIPath aiPath;
    IAstarAI ai;
    RobotTaskController taskController;

    public bool HasTask { get; private set; }

    private void Start()
    {
        aiPath = GetComponent<AIPath>();
        taskController = FindObjectOfType<RobotTaskController>();
        taskController.AddHarvester(this);
        taskController.DeclareFree(this);
        HasTask = false;

    }

    void Update()
    {
        DetermineWhatToDo();
    }

    private void DetermineWhatToDo()
    {
        aiPath.canMove = HasTask;
        aiPath.canSearch = HasTask;
    }

    internal void SetTask(HarvestTask task)
    {
        aiPath.destination = task.Destination.position;
        taskController.DeclareBusy(this);
        task.ClaimTask();
        HasTask = true;
    }
}
