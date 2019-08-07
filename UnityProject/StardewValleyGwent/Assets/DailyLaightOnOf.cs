using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class DailyLaightOnOf : MonoBehaviour
{
    public float changeOfIntensityTime = 0.5f;
    private float minBrightness = 0.15f;
    private float maxBrightness = 1;
    private Light2D light2D;
    private TimeManager timeManager;
    private const int SECONDS_IN_HOUR = 3600;
    void Awake()
    {
        light2D = GetComponentInChildren<Light2D>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    private void OnEnable()
    {
        TimeManager.OnBeginMorning += ReduceIntencityOfLight;
        TimeManager.OnBeginEvening += AddIntencityOfLight;
    }

    private void OnDisable()
    {
        TimeManager.OnBeginMorning -= ReduceIntencityOfLight;
        TimeManager.OnBeginEvening -= AddIntencityOfLight;
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
