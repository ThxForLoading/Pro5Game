using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Radio : MonoBehaviour
{

    [SerializeField] private AudioClip clipFreq1;
    [SerializeField] private AudioClip clipFreq2;
    [SerializeField] private AudioClip clipFreq3;
    [SerializeField] private AudioClip clipFreq4;

    private AudioSource audioSource;

    [SerializeField] private int goalFreq1 = 100;
    [SerializeField] private int goalFreq2;
    [SerializeField] private int goalFreq3;
    [SerializeField] private int goalFreq4;

    private GameObject pointer;
    private Transform pointerMinPos;
    private Transform pointerMaxPos;
    
    private int maxFreq = 200;
    private int minFreq = 0;
    private int freqStep = 5;
    private int currentFreq = 100;
    
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        pointer = GameObject.Find("RadioPointer");
        pointerMinPos = GameObject.Find("PointerMinPos").transform;
        pointerMaxPos = GameObject.Find("PointerMaxPos").transform;
        changePointerPos();
    }


    public void decreaseFreq()
    {
        if (currentFreq == minFreq) return;
        currentFreq -= freqStep;
        print("Decr Freq: " + currentFreq);
        checkFreq();
        changePointerPos();
    }
    
    public void increaseFreq()
    {
        if (currentFreq == maxFreq) return;
        currentFreq += freqStep;
        print("Incr Freq" + currentFreq);
        checkFreq();
        changePointerPos();
    }

    public void changePointerPos()
    {
        float pointerPos = (float)currentFreq / (float)maxFreq;
        pointer.transform.position = Vector3.Lerp(pointerMinPos.position, pointerMaxPos.position, pointerPos);
    }

    private void checkFreq()
    {

        if (currentFreq == goalFreq1)
        {
            audioSource.PlayOneShot(clipFreq1);
        } 
        else if (currentFreq == goalFreq2)
        {
            audioSource.PlayOneShot(clipFreq2);
        } 
        else if (currentFreq == goalFreq3)
        {
            audioSource.PlayOneShot(clipFreq3);
        } 
        else if (currentFreq == goalFreq4)
        {
            audioSource.PlayOneShot(clipFreq4);
        }
    }
}
