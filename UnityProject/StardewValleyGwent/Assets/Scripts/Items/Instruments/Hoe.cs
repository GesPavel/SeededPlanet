using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour, IGroundItem,IItem
{
    PlayerController player;
    Ground standingGround;
    [SerializeField] private string objectsName;
    public string ObjectsName => objectsName;

    void Start()
    {

    }


    void Update()
    {

    }

    public void Use(Ground ground)
    {
        if (ground != null)
        {
                ground.Plow();
        }
    }

}
