using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedFood : MonoBehaviour,IItem,IEatable
{
    [SerializeField] private string objectsName;
    public string ObjectsName => objectsName;
    [SerializeField] private float staminaRestoration = 25;
    public float StaminaRestoration => staminaRestoration;
}
