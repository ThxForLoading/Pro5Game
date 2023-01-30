using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchScript : MonoBehaviour
{


    public void GainTimePower()
    {
        //print("Gain time power.");
        GameObject clockChecker = GameObject.FindGameObjectWithTag("ClockCheck");
        clockChecker.GetComponent<ClockEnabler>().setClockActive();
        Destroy(gameObject);
    }
}
