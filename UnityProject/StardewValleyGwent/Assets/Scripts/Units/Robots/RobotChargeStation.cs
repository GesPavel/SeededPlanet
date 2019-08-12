using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotChargeStation : MonoBehaviour
{
    RobotHarvester robot;
    public GameObject robotPrefab;
    void Start()
    {
        GameObject robotObject = Instantiate(robotPrefab, this.transform.position, Quaternion.identity,this.transform);
        robot = robotObject.GetComponent<RobotHarvester>();
        robot.SetHome(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        robot.transform.position = transform.position;
        robot.transform.rotation = Quaternion.identity;
    }
}
