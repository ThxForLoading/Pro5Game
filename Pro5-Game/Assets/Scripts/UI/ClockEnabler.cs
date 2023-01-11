using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockEnabler : MonoBehaviour
{
    public bool clock;
    [SerializeField] GameObject UIClock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clock)
        {
            UIClock.SetActive(true);
        }    
    }

    public void setClockActive()
    {
        clock = true;
    }


}
