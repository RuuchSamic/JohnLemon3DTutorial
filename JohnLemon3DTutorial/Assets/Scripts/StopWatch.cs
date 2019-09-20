using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    private float prevTime = 0;
    private float interval;

    public bool repeatTime(float interval)
    {
        bool intervalMet = false;

        if (Time.time > prevTime + interval)
        {
            prevTime = Time.time;
            intervalMet = true;
        }
        return intervalMet;
    }
}
