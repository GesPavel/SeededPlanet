using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    Ground ground;
    public float staminaRestoration = 25; 
   
    public void SetGround(Ground ground)
    {
        this.ground = ground;
    }
    public Ground GetGround()
    {
        return ground;
    }
}
