using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedFood : MonoBehaviour, IItem, IEdibleItem, IBuffable
{
    [SerializeField] private string objectsName;
    public string ObjectsName => objectsName;
    [SerializeField] private float staminaRestoration;
    public float StaminaRestoration => staminaRestoration;
    public Sprite Icon => GetComponent<SpriteRenderer>().sprite;
    PlayerController player;
    public float buffSpeed;
    public float maxSpeedBuff;
    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    public void Buff()
    {
        if (player.speed < maxSpeedBuff)
        {
            player.speed = player.speed + buffSpeed;
        }
    }
}
