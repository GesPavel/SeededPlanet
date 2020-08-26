using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class SunScript : MonoBehaviour
{
    public float changeOfIntensityTime = 0.5f;
    public float minBrightness;
    public float maxBrightness;
    private UnityEngine.Experimental.Rendering.Universal.Light2D light2D;
    private TimeManager timeManager;
    private const int SECONDS_IN_HOUR = 3600;
    public float timer;
    PointLightOnObject[] pointLights;

    
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
        pointLights = FindObjectsOfType<PointLightOnObject>();
        light2D = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        timeManager = FindObjectOfType<TimeManager>();
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

    public void StartBlackOut()
    {
        ZeroLight();
        foreach (PointLightOnObject light in pointLights)
        {
            light.ZeroLight();
        }

    }
    public void StartNewDawn()
    {
        if (light2D.intensity <= 0.0f)
        {
            light2D.intensity = Bed.isMorningLight ? maxBrightness : minBrightness;
        }
    }

}



