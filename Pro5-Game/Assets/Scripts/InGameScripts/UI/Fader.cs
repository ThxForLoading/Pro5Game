using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{

    public static Fader fader;
    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private float fadeWait = 1f;
    [SerializeField] private Color fadeColor;
    private bool fading = false;
    private bool fadeIn = false;
    

    private RawImage img;

    private void Awake()
    {
        if (fader == null)
        {
            fader = this;
            img = GetComponent<RawImage>();
        }
        else
        {
            Debug.LogError("No multiple faders allowed!");
        }
        
    }


    public void CrossFade(Action onComplete)
    {
        if (!fading)
        {
           StartCoroutine(CrossFadeAlpha(onComplete)); 
        }
        
    }
    
    // public void FadeIn(Action onComplete)
    // {
    //     fadeIn = true;
    //     fading = true;
    //     StartCoroutine(Fade(onComplete));
    // }
    //
    // public void FadeOut(Action onComplete)
    // {
    //     fadeIn = false;
    //     fading = true;
    //     StartCoroutine(Fade(onComplete));
    // }
    
    IEnumerator CrossFadeAlpha(Action onComplete)
    {
        fading = true;
        
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            img.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, Mathf.Lerp(0, 1, time/fadeDuration));
            yield return null;
        }
        img.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1);

        
        if (onComplete != null)
        {
            onComplete();
        }

        yield return new WaitForSeconds(fadeWait);

        time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            img.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, Mathf.Lerp(1, 0, time/fadeDuration));
            yield return null;
        }
        img.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0);
        
        fading = false;

    }

    IEnumerator Fade(Action onComplete)
    {
        float targetAlpha = fadeIn ? 1 : 0;
        while (Mathf.Abs(img.color.a - targetAlpha) > 0.01f)
        {
            img.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, Mathf.Lerp(img.color.a, targetAlpha, fadeDuration * Time.deltaTime));
            yield return null;
        }

        img.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1);
        fading = false;

        if (onComplete != null)
        {
            onComplete();
        }
        
        
    }
}
