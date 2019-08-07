using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    private TimeManager timeManager;
    private Text clock;

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        clock = GetComponent<Text>();
    }

    private void Update()
    {
        DisplayTime();
    }

    private void DisplayTime()
    {
        StringBuilder fullTime = ComposeTime();
        clock.text = fullTime.ToString();

    }

    private StringBuilder ComposeTime()
    {
        StringBuilder emptyTime = new StringBuilder("");
        StringBuilder timeWithDays = emptyTime.Append(DayToDisplay());
        StringBuilder timeWithDaysAndHours = timeWithDays.Append(HourToDisplay());
        StringBuilder fullTime = timeWithDaysAndHours.Append(MinuteToDisplay());
        return fullTime;
    }

    private string DayToDisplay()
    {
        int dayCount = timeManager.CurrentDay;
        return "Day " + dayCount + " ";
    }

    private string HourToDisplay()
    {
        int hourCount = timeManager.Hours;
        return " " + hourCount + ":";
    }
    private string MinuteToDisplay()
    {
        int minuteCount = timeManager.Minutes;
        if (minuteCount < 10)
        {
            return "0" + minuteCount;
        }
        else
            return minuteCount.ToString();
    }
}
