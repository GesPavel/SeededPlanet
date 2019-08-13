using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour,IFurniture
{
    public GameObject wakeUpPoint;
    TimeManager time;
    public static int hoursForHealthySleep = 8;
    public static int hoursForFaint = 12;
    private void Start()
    {
        time = FindObjectOfType<TimeManager>();
    }

    public GameObject GetWakeUpPoint()
    {
        return wakeUpPoint;
    }
    public void Interact() {
        if (time.HoursSinceMidnight >= time.eveningHour)
        {
            SleepInHours(24 - time.HoursSinceMidnight + time.morningHour);
        }
        else if (time.HoursSinceMidnight < time.morningHour)
        {
            SleepInHours(time.morningHour - time.HoursSinceMidnight);
        }
        else
        {
            SleepInHours(time.eveningHour - time.HoursSinceMidnight);
        }
        
    }

    public void SleepInHours(int hours)
    {
        var player = FindObjectOfType<StaminaDirector>();
        if (player.WantToSleep())
        {
            time.SkipHours(hours);
            player.RestoreStamina();
        }
    }
}