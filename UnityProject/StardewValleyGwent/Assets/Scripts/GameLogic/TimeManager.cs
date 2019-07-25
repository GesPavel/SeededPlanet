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
            timer = timer - minuteInSeconds;
        }
    }

    private void StartNewMinute()
    {
       MinutesSinceNewHour++;
        if (MinutesSinceNewHour > 59)
        {
            BeginNextHour();
        }
    }

    private void BeginNextHour()
    {
        HoursSinceMidnight++;
        if (HoursSinceMidnight > 23)
        {
            startnewday();
        }
        MinutesSinceNewHour = 0;
    }

    private void startnewday()
    {
        CurrentDay++;
        HoursSinceMidnight = 0;
    }
}
