using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PointLightOnObject : MonoBehaviour
{
    public float changeOfIntensityTime = 0.5f;
    public float minBrightness;
    public float maxBrightness;
    private UnityEngine.Experimental.Rendering.Universal.Light2D light2D;
    private TimeManager timeManager;
    private const int SECONDS_IN_HOUR = 3600;
    public float timer;
    public float newTimer;

    void Awake()
    {
        light2D = GetComponentInChildren<UnityEngine.Experimental.Rendering.Universal.Light2D>();
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
        if (light2D.intensity > 0.0f)
        {

            float additive = (timeManager.timeSpeed * Time.fixedDeltaTime) / (SECONDS_IN_HOUR * changeOfIntensityTime);
            light2D.intensity += additive;
            light2D.intensity = Mathf.Clamp(light2D.intensity, minBrightness, maxBrightness);
        }
    }

    private void ReduceIntencityOfLight()
    {
        if (light2D.intensity > 0.0f)
        {

            float reduction = (timeManager.timeSpeed * Time.fixedDeltaTime) / (SECONDS_IN_HOUR * changeOfIntensityTime);
            light2D.intensity -= reduction;
            light2D.intensity = Mathf.Clamp(light2D.intensity, minBrightness, maxBrightness);
        }
    }

    public void ZeroLight()
    {
        light2D.intensity = 0.0f;
    }
    public void Update()
    {
        if (light2D.intensity <= 0.0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                light2D.intensity = Bed.isMorningLight ? minBrightness : maxBrightness;
                timer = newTimer;
            }
        }
    }

}
