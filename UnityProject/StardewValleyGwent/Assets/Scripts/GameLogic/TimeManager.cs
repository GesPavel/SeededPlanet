using System;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    public static event EventManager.TimeEvent OnBeginMorning;
    public static event EventManager.TimeEvent OnBeginEvening;
    public int MinutesSinceNewHour { get { return ((int)SecondsSinceMidnight % SECONDS_IN_HOUR) / SECONDS_IN_MINUTE;} }
    public int HoursSinceMidnight { get {return ((int)SecondsSinceMidnight / SECONDS_IN_HOUR);} }
    public int CurrentDay { get; private set; } = 1;
    public float SecondsSinceMidnight { get; private set; } = SECONDS_IN_DAY / 2;

    public float SecondsSinceGameStart { get; private set; } = 0;

    public float timeSpeed;
    public int morningHour = 8;
    public int eveningHour = 18;
    public bool timeWasSkipped = false;
    


    private const int SECONDS_IN_DAY=86400;
    private const int SECONDS_IN_HOUR = 3600;
    private const int SECONDS_IN_MINUTE = 60;
    private void Update()
    {
        SecondsSinceMidnight += Time.deltaTime*timeSpeed * Time.timeScale;
        SecondsSinceGameStart += Time.deltaTime * Time.timeScale;
        if (SecondsSinceMidnight >= SECONDS_IN_DAY)
        {
            CurrentDay++;
            SecondsSinceMidnight %= SECONDS_IN_DAY;
        }
        
        if(SecondsSinceMidnight>morningHour*SECONDS_IN_HOUR && SecondsSinceMidnight < eveningHour * SECONDS_IN_HOUR)
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
        SecondsSinceMidnight += hours * SECONDS_IN_HOUR;
        SecondsSinceGameStart += hours * SECONDS_IN_HOUR;
        timeWasSkipped = true;
    }
}
