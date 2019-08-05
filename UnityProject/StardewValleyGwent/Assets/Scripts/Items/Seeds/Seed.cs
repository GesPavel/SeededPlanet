using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour, IGroundItem,IItem
{
    PlayerController player;
    public Ground StandingGround { get; private set; }
    [SerializeField] private string objectsName;
    public string ObjectsName => objectsName;
    public Sprite Icon => GetComponent<SpriteRenderer>().sprite;

    public GameObject plant;


    public void Use(Ground ground)
    {
        if (ground != null)
        {
            if (ground.isOccupiedByPlant) return;
            if (!ground.IsPlowed)
            {
                Destroy(this.gameObject);
                return;
            }
            ground.AddPlant(this.plant);
            Destroy(this.gameObject);
        }
    }
}