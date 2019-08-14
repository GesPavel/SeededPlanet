using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour,IFurniture
{
    public GameObject wakeUpPoint;
    SunScript dream;
    PointLightOnObject[] pointLights;
    TimeManager time;
    StaminaDirector player;
    public static int hoursForHealthySleep = 8;
    public static int hoursForFaint = 12;
    public static bool isMorningLight;

    private void Start()
    {
        player = FindObjectOfType<StaminaDirector>();
        time = FindObjectOfType<TimeManager>();
        dream = FindObjectOfType<SunScript>();
        pointLights = FindObjectsOfType<PointLightOnObject>();
    }

    public GameObject GetWakeUpPoint()
    {
        return wakeUpPoint;
    }
    public void Interact() {
        if (time.HoursSinceMidnight >= time.eveningHour)
        {
            isMorningLight = true;
            SleepInHours(24 - time.HoursSinceMidnight + time.morningHour);
        }
        else if (time.HoursSinceMidnight < time.morningHour)
        {
            isMorningLight = true;
            SleepInHours(time.morningHour - time.HoursSinceMidnight);
        }
        else
        {
            isMorningLight = false;
            SleepInHours(time.eveningHour - time.HoursSinceMidnight);
        }
        
    }

    public void SleepInHours(int hours)
    {
        if (player.WantToSleep())
        {
            dream.ZeroLight();
            foreach (PointLightOnObject light in pointLights)
            {
                light.ZeroLight();
            }
            time.SkipHours(hours);
            player.RestoreStamina();
            player.gameObject.SetActive(false);
            Invoke("WakeUpPlayer", 2.0f);    
        }
    }
    void WakeUpPlayer()
    {
        player.gameObject.SetActive(true);
    }
    
    
}