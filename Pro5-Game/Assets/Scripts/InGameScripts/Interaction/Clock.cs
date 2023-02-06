using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class Clock : MonoBehaviour
{

    [SerializeField] private FPEDrawer drawer;
    [SerializeField] AudioClip drawerOpen;
    private float rotationGoal = -540.0f;    
    [SerializeField] GameObject pointerBase;
    [SerializeField] GameObject hourPointerBase;
    private float rotationPerAction = 90.0f;
    private float currentRotation = 0.0f;
    private bool drawerOpened;

    private AudioSource audioSource;
    
    
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TurnClock(bool turnForward)
    {
        if (turnForward)
        {
            pointerBase.transform.Rotate(0, 0,rotationPerAction);
            hourPointerBase.transform.Rotate(0, 0,rotationPerAction / 12f);
            currentRotation += rotationPerAction;
        }
        else
        {
            pointerBase.transform.Rotate(0, 0,-rotationPerAction);
            hourPointerBase.transform.Rotate(0, 0,-rotationPerAction / 12f);
            currentRotation -= rotationPerAction;
        }

        if (drawerOpened) return;

        float diff = rotationGoal - currentRotation;
        
        // 4320 is 12 hours rotation
        if ((diff < 0.1f && diff > -0.1f) || diff < (-4319))
        {
            drawerOpened = true;
            drawer.ExternallyUnlockDrawer();
            drawer.openTheDrawer();
            audioSource.PlayOneShot(drawerOpen);

            //GameObject cam = GameObject.Find("FPEPlayerController(Clone)");
            FPEFirstPersonController controller = FindObjectOfType<FPEFirstPersonController>();
            controller.forcePlayerLookToPosition(drawer.transform.position);
            //controller.transform.LookAt(drawer.transform);
        }
    }
}
