using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class Clock : MonoBehaviour
{

    [SerializeField] private FPEDrawer drawer;
    [SerializeField] AudioClip drawerOpen;
    private float rotationGoal = -240.0f;    
    [SerializeField] GameObject pointerBase;
    [SerializeField] GameObject hourPointerBase;
    private float rotationPerAction = 30.0f;
    private float currentRotation = 0.0f;
    
    
    // public void Awake()
    // {
    //     pointerBase = GameObject.Find("PointerBase");
    //     hourPointerBase = GameObject.Find("HourPointerBase");
    // }

    public void TurnClock(bool turnForward)
    {
        if (turnForward)
        {
            print("Turn forward");
            pointerBase.transform.Rotate(0, 0,rotationPerAction);
            hourPointerBase.transform.Rotate(0, 0,rotationPerAction / 12f);
            currentRotation += rotationPerAction;
        }
        else
        {
            print("Turn backward");
            pointerBase.transform.Rotate(0, 0,-rotationPerAction);
            hourPointerBase.transform.Rotate(0, 0,-rotationPerAction / 12f);
            currentRotation -= rotationPerAction;
        }
        


        float diff = rotationGoal - currentRotation;
        if ( diff < 0.1f && diff > -0.1f)
        {
            drawer.ExternallyUnlockDrawer();
            drawer.openTheDrawer();
        }
    }
}
