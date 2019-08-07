using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class SunScript : MonoBehaviour
{
    public float changeOfIntensityTime = 0.5f;
    private float minBrightness = 0.15f;
    private float maxBrightness = 1;
    private Light2D light2D;
    private TimeManager timeManager;
    private const int SECONDS_IN_HOUR = 3600;
    

    private void OnEnable()
    {
        TimeManager.OnBeginMorning += AddIntencityOfLight; 
        TimeManager.OnBeginEvening += ReduceIntencityOfLight; 
    }
    private void OnDisable()
    {
        TimeManager.OnBeginMorning -= AddIntencityOfLight;
        TimeManager.OnBeginEvening -= ReduceIntencityOfLight;
    }
    private void Awake()
    {
        light2D = GetComponent<Light2D>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    private void AddIntencityOfLight()
    {
        float additive = (timeManager.timeSpeed * Time.fixedDeltaTime) / (SECONDS_IN_HOUR * changeOfIntensityTime);
        light2D.intensity += additive;
        light2D.intensity = Mathf.Clamp(light2D.intensity, minBrightness, maxBrightness);
    }

    private void ReduceIntencityOfLight()
    {
        float reduction = (timeManager.timeSpeed * Time.fixedDeltaTime) / (SECONDS_IN_HOUR * changeOfIntensityTime);
        light2D.intensity -= reduction;
        light2D.intensity = Mathf.Clamp(light2D.intensity, minBrightness, maxBrightness);
    }
}
