using System;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    public int MinutesSinceNewHour { get; private set; }
    public int HoursSinceMidnight { get; private set; }
    public int CurrentDay { get; private set; }

    [SerializeField] private float minuteInSeconds = 0.1f;
    float timer;
    
    void Start()
    {
        CurrentDay = 1;
        HoursSinceMidnight = 8;
        MinutesSinceNewHour = 0;

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > minuteInSeconds)
        {
            StartNewMinute();
            timer -= minuteInSeconds;
        }
    }

    private void StartNewMinute()
    {
       MinutesSinceNewHour++;
       CheckIfNewHour();
    }

    private void CheckIfNewHour()
    {
        if (MinutesSinceNewHour >= 60)
        {
            BeginNextHour();
            MinutesSinceNewHour -= 60;
            CheckIfNewHour();
        }
    }

    private void BeginNextHour()
    {
        HoursSinceMidnight++;
        CheckIfNewDay();
    }

    private void CheckIfNewDay()
    {
        if(HoursSinceMidnight >= 24)
        {
            StartNewDay();
            HoursSinceMidnight -= 24;
            CheckIfNewDay();
        }
    }

    private void StartNewDay()
    {
        CurrentDay++;
    }

    public void SkipHours(int hours)
    {
        HoursSinceMidnight += hours;
        CheckIfNewDay();
    }
}
