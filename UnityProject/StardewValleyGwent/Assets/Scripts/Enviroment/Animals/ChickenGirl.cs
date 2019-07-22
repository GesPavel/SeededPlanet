using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGirl : Animal
{
    public GameObject egg;
    bool outOfEggs = false;
    float timeToSex = -1;
    public override void OnCollisionEnter2D(Collision2D coll)
    {
        base.OnCollisionEnter2D(coll);
        
        if (!outOfEggs)
        {
            if (coll.gameObject.tag == "ChickenMale")
            {
                Debug.Log("Женитес");
                GameObject thisEgg = Instantiate(egg, transform.position, Quaternion.identity);
                speed = Random.Range(0.5f, 2);
                direction.x = direction.x * Mathf.Sin(Random.Range(2 * Mathf.PI / 3, 4 * Mathf.PI / 3));
                direction.y = direction.y * Mathf.Sin(Random.Range(2 * Mathf.PI / 3, 4 * Mathf.PI / 3));
                timeForStop = Random.Range(-1, -5);
                outOfEggs = true;
                
            }
        }
    }
    public override void Update()
    {
        base.Update();
        if (outOfEggs)
        {
            timeToSex += Time.deltaTime;
            if (timeToSex > 0)
            {
                outOfEggs = false;
                timeToSex = -5;
            }
        }
    }

}
