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

    [SerializeField] private float startFreq = 100;
    [SerializeField] private float goalFreq1 = 100;
    [SerializeField] private float goalFreq2;
    [SerializeField] private float goalFreq3;
    [SerializeField] private float goalFreq4;

    [SerializeField] GameObject pointer;
    private Transform pointerMinPos;
    private Transform pointerMaxPos;
    
    [SerializeField] float maxFreq = 200;
    [SerializeField] float minFreq = 0;
    private float freqStep = 2.5f;
    private float currentFreq;
    
    

    private void Awake()
    {
        currentFreq = startFreq;
        audioSource = GetComponent<AudioSource>();
        pointerMinPos = GameObject.Find("PointerMinPos").transform;
        pointerMaxPos = GameObject.Find("PointerMaxPos").transform;
        ChangePointerPos();
    }


    public void DecreaseFreq()
    {
        if (currentFreq - minFreq <= 0.1f && currentFreq - minFreq >= -0.1f) return;
        currentFreq -= freqStep;
        print("Decr Freq: " + currentFreq);
        CheckFreq();
        ChangePointerPos();
    }
    
    public void IncreaseFreq()
    {
        if (currentFreq - maxFreq <= 0.1f && currentFreq - maxFreq >= -0.1f) return;
        currentFreq += freqStep;
        print("Incr Freq" + currentFreq);
        CheckFreq();
        ChangePointerPos();
    }

    public void ChangePointerPos()
    {
        float pointerPos = (currentFreq - minFreq) / (maxFreq - minFreq) ;
        pointer.transform.position = Vector3.Lerp(pointerMinPos.position, pointerMaxPos.position, pointerPos);
    }

    private void CheckFreq()
    {

        if (currentFreq - goalFreq1 <= 0.1f && currentFreq - goalFreq1 >= -0.1f)
        {
            audioSource.clip = clipFreq1;
            audioSource.Play();
            //audioSource.PlayOneShot(clipFreq1);
        } 
        else if (currentFreq - goalFreq2 <= 0.1f && currentFreq - goalFreq2 >= -0.1f)
        {
            audioSource.clip = clipFreq2;
            audioSource.Play();
        } 
        else if (currentFreq - goalFreq3 <= 0.1f && currentFreq - goalFreq3 >= -0.1f)
        {
            audioSource.clip = clipFreq3;
            audioSource.Play();
        } 
        else if (currentFreq - goalFreq4 <= 0.1f && currentFreq - goalFreq4 >= -0.1f)
        {
            audioSource.clip = clipFreq4;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = null;
        }
    }

    public void StopMorse()
    {
        audioSource.clip = null;
    }
}
