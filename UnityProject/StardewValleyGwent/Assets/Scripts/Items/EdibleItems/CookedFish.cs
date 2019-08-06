using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedFish : MonoBehaviour, IItem, IEdibleItem, IBuffable
{
    [SerializeField]
    private string objectsName;
    public string ObjectsName => objectsName;
    [SerializeField]
    private float staminaRestoration;
    public float StaminaRestoration => staminaRestoration;
    public Sprite Icon => GetComponent<SpriteRenderer>().sprite;
    StaminaDirector stamina;
    public float maxMaxStamina;
    public float buffStamina;
    public void Start()
    {
        stamina = FindObjectOfType<StaminaDirector>();

    }
    public void Buff()
    {
        
        if (stamina.maxStamina<maxMaxStamina)
        {
            stamina.maxStamina += buffStamina;
        }
    }

}
