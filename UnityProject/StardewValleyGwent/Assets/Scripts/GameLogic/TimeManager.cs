using System;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    public static event EventManager.TimeEvent OnBeginMorning;
    public static event EventManager.TimeEvent OnBeginEvening;
    public int Minutes { get { return ((int)Seconds % SECONDS_IN_HOUR) / SECONDS_IN_MINUTE;} }
    public int Hours { get {return ((int)Seconds / SECONDS_IN_HOUR);} }
    public int CurrentDay { get; private set; } = 1;
    public float Seconds { get; private set; } = SECONDS_IN_DAY / 2;

    public float timeSpeed = 1f;
    public float morningHour = 8f;
    public float eveningHour = 20f;

    


    private const int SECONDS_IN_DAY=86400;
    private const int SECONDS_IN_HOUR = 3600;
    private const int SECONDS_IN_MINUTE = 60;
    private void FixedUpdate()
    {
        Seconds += Time.fixedDeltaTime*timeSpeed;
        if (Seconds >= SECONDS_IN_DAY)
        {
            CurrentDay++;
            Seconds %= SECONDS_IN_DAY;
        }
        
        if(Seconds>morningHour*SECONDS_IN_HOUR && Seconds < eveningHour * SECONDS_IN_HOUR)
        {
            OnBeginMorning();
        }
        else
        {
            OnBeginEvening();
        }
    }
    public void SkipHours(int hours)
    {
        Seconds += hours * SECONDS_IN_HOUR;
    }
}
