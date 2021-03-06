﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingFloat : MonoBehaviour
{
    float timeUnderTheWater;
    float timeAboveTheWater;
    public static bool youCanGetFish;
    bool changeToUnder,changeToAbove;
    public float maxRangeAbove;
    public float minRangeAboveAndUnder;
    public float maxRangeUnder;



    void Start()
    {
        timeAboveTheWater = Random.Range(minRangeAboveAndUnder, maxRangeAbove);
        timeUnderTheWater = -1;
        changeToUnder = true;
        changeToAbove = false;
    }

    void BehaveUnderTheWater()
    {

        if (timeUnderTheWater >= 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            timeUnderTheWater -= Time.deltaTime * Time.timeScale;
            youCanGetFish = true;
        }
        if (timeUnderTheWater < 0)
        {
            if (changeToAbove)
            {
                timeAboveTheWater = Random.Range(minRangeAboveAndUnder, maxRangeAbove);
                changeToUnder = true;
                changeToAbove = false;

            }

        }

    }
    void BehaveAboveTheWater()
    {
        if (timeAboveTheWater >= 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            timeAboveTheWater -= Time.deltaTime * Time.timeScale;
            youCanGetFish = false;
        }
        if (timeAboveTheWater < 0)
        {
            if (changeToUnder)
            {
                timeUnderTheWater = Random.Range(minRangeAboveAndUnder, maxRangeUnder);
                changeToAbove = true;
                changeToUnder = false;
            }
        }

    }
    void Update()
    {
        BehaveAboveTheWater();
        BehaveUnderTheWater();
    }
    /*

        */
}
