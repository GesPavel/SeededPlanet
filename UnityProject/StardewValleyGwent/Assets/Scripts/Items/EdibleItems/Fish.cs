﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, IItem, IEdibleItem
{
    [SerializeField]
    private string objectsName = "Fish";
    public string ObjectsName => objectsName;
    public Sprite Icon => GetComponent<SpriteRenderer>().sprite;

    [SerializeField]
    private float staminaRestoration = 25;
    public float StaminaRestoration => staminaRestoration;
    void Start()
    {
    }
}
