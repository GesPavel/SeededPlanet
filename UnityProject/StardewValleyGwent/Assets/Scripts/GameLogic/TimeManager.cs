using System;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    public int MinutesSinceNewHour { get; private set; } = 0;
    public int HoursSinceMidnight { get; private set; } = 0;
    public int CurrentDay { get; private set; } = 1;

    public float timeSpeed = 1f;
    float seconds;


    private void Update()
    {
        seconds += Time.deltaTime*timeSpeed;
        if (seconds >= 86400)
        {
            CurrentDay++;
            seconds %= 86400;
        }
        MinutesSinceNewHour = ((int)seconds / 60) % 60;
        HoursSinceMidnight = ((int)seconds / 3600) % 24;
        Debug.Log($"seconds {seconds} current hour{(seconds/3600)%24}");
    }

    public void SkipHours(int hours)
    {
        seconds += hours * 3600;
    }
}
