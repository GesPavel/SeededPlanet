using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour,ITransferable,IEatable
{
    Ground ground;
    [SerializeField]private float staminaRestoration = 25;
    public float StaminaRestoration => staminaRestoration;
    public void SetGround(Ground ground)
    {
        this.ground = ground;
        this.ground.isOccupied = true;
    }
    public Ground GetGround()
    {
        return ground;
    }
}
