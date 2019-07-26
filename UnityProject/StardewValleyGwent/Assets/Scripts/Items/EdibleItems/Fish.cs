using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, IItem, IEdible
{
    [SerializeField]
    private string objectsName = "Fish";
    public string ObjectsName => objectsName;

    [SerializeField]
    private float staminaRestoration = 25;
    public float StaminaRestoration => staminaRestoration;
    void Start()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Ceil(pos.x) + 0.5f;
        pos.y = Mathf.Ceil(pos.y) + 0.5f;
        transform.position = pos;
    }
}
