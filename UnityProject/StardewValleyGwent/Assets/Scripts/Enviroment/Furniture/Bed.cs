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
        
        SleepInHours(hoursForHealthySleep);
    }

    public void SleepInHours(int hours)
    {
        time.SkipHours(hours);
        var player = FindObjectOfType<StaminaDirector>();
        player.RestoreStamina();
    }
}