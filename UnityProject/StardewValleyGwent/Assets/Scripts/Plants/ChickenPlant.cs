using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPlant : Plant
{
    public override void InstantiateVegetable()
    {
        GameObject newVegetable = Instantiate(vegetable[Random.Range(0,1)], transform.position, Quaternion.identity);
        ground.isOccupiedByPlant = false;
    }
}
