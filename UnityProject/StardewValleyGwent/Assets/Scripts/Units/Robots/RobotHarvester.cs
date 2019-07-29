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
    RobotStrategy strategy;
    GameObject itemInHand;

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
        if (itemInHand != null)
        {
            itemInHand.transform.position = transform.position;
            itemInHand.transform.up = transform.up;
        }
    }

    private void DetermineWhatToDo()
    {
        aiPath.canMove = HasTask;
        aiPath.canSearch = HasTask;
        if (aiPath.reachedEndOfPath)
        {
            Debug.Log(1);
            OnPathComplete();
        }
    }

    public void SetTask(AbstractTask task)
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
        strategy.Act();
    }
    public void PickUpItem(GameObject item)
    {
        itemInHand = item;
    }
    internal void StoreItem(UniversalCrate crate)
    {
        crate.ChangeItem(itemInHand);
    }
    public void SetDistanceToPathComplete(float dist)
    {
        aiPath.endReachedDistance = dist;
    }
    public float GetDistanceToPathComplete()
    {
        return aiPath.endReachedDistance;
    }
}
