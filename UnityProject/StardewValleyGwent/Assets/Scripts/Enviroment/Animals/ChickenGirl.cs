using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGirl : Animal
{
    public GameObject egg;
    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Chicken")
        {
                Debug.Log("Женитес");
                GameObject thisEgg = Instantiate(egg, transform.position, Quaternion.identity);
                speed = Random.Range(0.5f, 2);
                direction.x = direction.x * (-1) * Mathf.Sin(Random.Range(2 * Mathf.PI / 3, 4 * Mathf.PI / 3));
                direction.y = direction.y * (-1) * Mathf.Sin(Random.Range(2 * Mathf.PI / 3, 4 * Mathf.PI / 3));
                timeForStop = Random.Range(-1, -5);
        }
    }

}
