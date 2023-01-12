using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchScript : MonoBehaviour
{
    GameObject clockChecker;
    // Start is called before the first frame update
    void Start()
    {
        clockChecker = GameObject.FindGameObjectWithTag("ClockCheck");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainTimePower()
    {
        clockChecker.GetComponent<ClockEnabler>().setClockActive();
        Destroy(gameObject);
    }
}
