using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class RobotHarvester : MonoBehaviour
{
    AIPath aiPath;
    RobotTaskController taskController;
    RobotStrategy strategy;
    public GameObject itemInManipulator;
    float distanceToPathComplete = 0.1f;


    public bool HasTask { get; set; }

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
        MoveItemWithRobot();

    }

    private void MoveItemWithRobot()
    {
        if (itemInManipulator != null)
        {
            itemInManipulator.transform.position = transform.position;
            itemInManipulator.transform.up = transform.up;
        }
    }

    public void SetFree()
    {
        taskController.DeclareFree(this);
        HasTask = false;
        strategy = null;

        aiPath.destination = Vector3.positiveInfinity;
    }

    private void DetermineWhatToDo()
    {
        Debug.Log(aiPath.destination);
        aiPath.canMove = HasTask;
        aiPath.canSearch = HasTask;
        if ((aiPath.destination - gameObject.transform.position).magnitude <= distanceToPathComplete && HasTask)
        {
            Debug.Log((aiPath.destination - gameObject.transform.position).magnitude);
                OnPathComplete();
        }
    }

    public void ReceiveTask(AbstractTask task)
    {
        aiPath.destination = task.Destination.position;
        if (!HasTask)
        {
            taskController.DeclareBusy(this);
            HasTask = true;
        }
        task.ClaimTask();
        gameObject.AddComponent(task.GetStrategyAccordingToType());

    }
    private void OnPathComplete()
    {
        strategy = GetComponent(typeof(RobotStrategy)) as RobotStrategy;
        if (strategy != null)
        {
            strategy.Act();
        }
    }
    public void PickUpItem(GameObject item)
    {
        itemInManipulator = item;
    }
    internal void StoreItem(UniversalCrate crate)
    {
        itemInManipulator = crate.TradeItem(itemInManipulator);
    }
    public void SetDistanceToPathComplete(float dist)
    {
        distanceToPathComplete = dist;
    }
    public float GetDistanceToPathComplete()
    {
        return distanceToPathComplete;
    }
}
