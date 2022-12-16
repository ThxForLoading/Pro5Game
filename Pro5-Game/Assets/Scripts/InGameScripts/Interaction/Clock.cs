using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class Clock : FPEInteractableActivateScript
{

    [SerializeField] private FPEDrawer drawer;
    [SerializeField] AudioClip drawerOpen;
    private float rotationGoal = -120.0f;    
    private GameObject pointerBase;
    private GameObject hourPointerBase;
    private float rotationPerAction = -30.0f;
    private float currentRotation = 0.0f;
    
    
    public override void Awake()
    {
        base.Awake();
        pointerBase = GameObject.Find("PointerBase");
        hourPointerBase = GameObject.Find("HourPointerBase");
    }

    public void turnClock()
    {
        pointerBase.transform.Rotate(0, rotationPerAction, 0);
        hourPointerBase.transform.Rotate(0, rotationPerAction / 60f, 0);
        currentRotation += rotationPerAction;
        
        
        // pointerBase.transform.rotation = Quaternion.Lerp(
        //     pointerBase.transform.rotation, 
        //     Quaternion.Euler(0, pointerBase.transform.eulerAngles.y + rotationPerAction, 0),
        //     0.4f);
        
        float diff = rotationGoal - currentRotation;
        if ( diff < 0.1f && diff > -0.1f)
        {
            drawer.ExternallyUnlockDrawer();
            drawer.openTheDrawer();
        }
    }
}
