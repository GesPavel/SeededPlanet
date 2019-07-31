using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractTask : MonoBehaviour
{
    public Transform Destination { get; set; }
    bool inProgress = false;
    protected RobotTaskController taskController;

    private void Awake()
    {
        taskController = FindObjectOfType<RobotTaskController>();
        DetermineDestination();
        AddToTaskListIfNecessary();
    }

    abstract protected void DetermineDestination();

    protected abstract void AddToTaskListIfNecessary();


    public void ClaimTask()
    {
        inProgress = true;
        RemoveFromTaskListIfNecessary();
    }
     public void FailTask()
    {
        Destroy(this);
    }
    protected abstract void RemoveFromTaskListIfNecessary();


    public bool IsInProgress()
    {
        return inProgress;
    }
    public abstract Type GetStrategyAccordingToType();

    public void SetComplete()
    {
        Destroy(this);
    }
}