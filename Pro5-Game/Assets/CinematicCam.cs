using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Whilefun.FPEKit;

public class CinematicCam : MonoBehaviour
{
    [SerializeField] private float time;
    private float timeTillAction = 0.5f;

    private FPEInteractionManagerScript interactionManager;
    private Camera mainCam;
    private Camera cam;
    private GameObject interactionLabel;
    

    private void Start()
    {
        mainCam = GameObject.Find("MainCamera").GetComponent<Camera>();
        interactionLabel = GameObject.Find("InteractionTextLabel");
        interactionManager = FindObjectOfType<FPEInteractionManagerScript>();
        cam = GetComponent<Camera>();
        
        
        cam.enabled = false;

    }

    public void playSequence()
    {
        StartCoroutine(sequence());
    }



    private IEnumerator sequence()
    {
        mainCam.enabled = false;
        cam.enabled = true;
        interactionLabel.SetActive(false);
        interactionManager.BeginCutscene();
        yield return new WaitForSeconds(time);
        mainCam.enabled = true;
        cam.enabled = false;
        interactionLabel.SetActive(true);
        interactionManager.EndCutscene();
    }
}
