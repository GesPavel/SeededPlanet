using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour,IItem,IEdible
{
    [SerializeField] private string objectsName = "Egg";
    public string ObjectsName => objectsName;

    [SerializeField]private float staminaRestoration = 25;
    public float StaminaRestoration =>staminaRestoration;

    void Start()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Ceil(pos.x)+0.5f;
        pos.y = Mathf.Ceil(pos.y)+0.5f;
        transform.position = pos;
    }

}
