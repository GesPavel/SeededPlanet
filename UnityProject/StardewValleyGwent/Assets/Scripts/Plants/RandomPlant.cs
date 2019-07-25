using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlant : Plant
{
    int vegetableArrayRange;
    public override void InstantiateVegetable()
    {
        GameObject newVegetable = Instantiate(vegetable[vegetableArrayRange], transform.position, Quaternion.identity);
        ground.isOccupiedByPlant = false;
    }
    public override void Update()
    {
        base.Update();
        vegetableArrayRange = Random.Range(0,vegetable.Length);
    }
}
