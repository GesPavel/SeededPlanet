using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTaskController : MonoBehaviour
{
    public List<RobotHarvester> harvesters;
    public List<RobotHarvester> freeHarvesters;
    List<HarvestTask> harvestTasks;

    void Awake()
    {
        harvesters = new List<RobotHarvester>();
        freeHarvesters = new List<RobotHarvester>();
        harvestTasks = new List<HarvestTask>();
    }
    private void Update()
    {
        for (int i = 0; i < freeHarvesters.Count; i++)
        {
            if (harvestTasks.Count != 0)
            {
                Notify(freeHarvesters[i], harvestTasks[0]);
            }
        }
    }
    public void AddHarvester(RobotHarvester harvester)
    {
        harvesters.Add(harvester);
    }

    public void RemoveHarvester(RobotHarvester harvester)
    {
        harvesters.Remove(harvester);
    }

    public void AddHarvestTask(HarvestTask harvestTask)
    {
        harvestTasks.Add(harvestTask);

    }

    public void RemoveHarvestTask(HarvestTask harvestTask)
    {
        harvestTasks.Remove(harvestTask);
    }

    public void DeclareFree(RobotHarvester harvester)
    {
        
        freeHarvesters.Add(harvester);
    }
    public void DeclareBusy(RobotHarvester harvester)
    {
        freeHarvesters.Remove(harvester);
    }
    private void Notify(RobotHarvester harvester, HarvestTask task)
    {
        harvester.SetTask(task);

    }
}
