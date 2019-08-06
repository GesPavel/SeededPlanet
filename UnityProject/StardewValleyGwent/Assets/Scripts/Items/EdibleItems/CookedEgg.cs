using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedEgg : MonoBehaviour, IItem, IEdibleItem, IBuffable
{
    [SerializeField]
    private string objectsName;
    public string ObjectsName => objectsName;
    [SerializeField]
    private float staminaRestoration;
    public float StaminaRestoration => staminaRestoration;
    public Sprite Icon => GetComponent<SpriteRenderer>().sprite;
    public void Start()
    {

    }
    public void Buff()
    {

    }
}
