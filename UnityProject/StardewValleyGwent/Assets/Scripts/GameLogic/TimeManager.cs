using System;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    public int Minutes { get { return ((int)Seconds % secondsInHour) / secondsInMinute;} }
    public int Hours { get {return ((int)Seconds / secondsInHour) % hoursInDay; } }
    public int CurrentDay { get; private set; } = 1;
    public float timeSpeed = 1f;
    public float Seconds { get; private set;}

    private const int secondsInDay=86400;
    private const int secondsInHour = 3600;
    private const int secondsInMinute = 60;
    private const int hoursInDay = 24;
  


    private void Update()
    {
        Seconds += Time.deltaTime*timeSpeed;
        if (Seconds >= secondsInDay)
        {
            CurrentDay++;
            Seconds %= secondsInDay;
        }      
    }
    public void SkipHours(int hours)
    {
        Seconds += hours * secondsInHour;
    }
}
