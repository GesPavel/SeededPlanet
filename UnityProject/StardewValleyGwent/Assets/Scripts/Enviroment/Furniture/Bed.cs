using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject wakeUpPoint;
    SunScript sun;
    
    TimeManager time;
    StaminaDirector player;
    public static int hoursForHealthySleep = 8;
    public static int hoursForFaint = 12;
    public static bool isMorningLight;

    private void Start()
    {
        player = FindObjectOfType<StaminaDirector>();
        time = FindObjectOfType<TimeManager>();
        sun = FindObjectOfType<SunScript>();
        Time.timeScale = 1;
        Debug.Log(Time.deltaTime * Time.timeScale);
    }

    public GameObject GetWakeUpPoint()
    {
        return wakeUpPoint;
    }
    public void OnTriggerStay2D()
    {
        if (!player.Restored())
        {
            SleepInHours();
        }
        else
        {
            WakeUpPlayer();
        }
    }

    public void OnTriggerEnter2D()
    {
        if (!player.Restored())
        {
            sun.StartBlackOut();
        }
    }

    public void SleepInHours()
    {
        player.IncreaseStamina(0.1f);
        player.GetComponent<PlayerController>().enabled = false;
        Time.timeScale = 20;
    }

    void WakeUpPlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
        Time.timeScale = 1;
        sun.StartNewDawn();
    }


}