using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    GameObject wakeUpPoint;
    private void Start()
    {
        Vector2 wakeUpPointPosition = 
            new Vector2(this.transform.position.x + 1, this.transform.position.y);
            wakeUpPoint = Instantiate(FindObjectOfType<EmptyPoint>().gameObject, wakeUpPointPosition,
            Quaternion.identity);
    }

    public GameObject GetWakeUpPoint()
    {
        return wakeUpPoint;
    }
}
