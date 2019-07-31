using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedFood : MonoBehaviour, IItem, IEdibleItem, IBuffable
{
    [SerializeField] private string objectsName;
    public string ObjectsName => objectsName;
    [SerializeField] private float staminaRestoration = 40;
    public float StaminaRestoration => staminaRestoration;
    PlayerController player;
    public float buffSpeed;
    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    public void Buff()
    {
        if (player.speed < 15)
        {
            player.speed = player.speed + buffSpeed;
        }
    }
}
