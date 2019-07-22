using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour,ITransferable,IEatable
{
    [SerializeField]private float staminaRestoration = 25;
    public float StaminaRestoration => staminaRestoration;
}
