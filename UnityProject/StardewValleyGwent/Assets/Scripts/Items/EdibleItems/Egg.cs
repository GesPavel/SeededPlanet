using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour,IItem,IEdibleItem
{
    [SerializeField] private string objectsName = "Egg";
    public string ObjectsName => objectsName;

    [SerializeField]private float staminaRestoration = 25;
    public float StaminaRestoration =>staminaRestoration;

}
