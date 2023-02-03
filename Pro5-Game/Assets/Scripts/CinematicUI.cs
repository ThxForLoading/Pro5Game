using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class CinematicUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    
    private FPEInteractionManagerScript im;
    private bool uiActive = false;
    
    
    void Start()
    {
        im = FindObjectOfType<FPEInteractionManagerScript>();
        UI.SetActive(false);
    }

    public void startCinematic()
    {
        uiActive = true;
        UI.SetActive(true);
        //im.BeginCutscene(true);
        FPEInteractionManagerScript.Instance.BeginCutscene(true);
    }

    public void stopCinematic()
    {
        uiActive = false;
        UI.SetActive(false);
        //im.EndCutscene(true);
        FPEInteractionManagerScript.Instance.EndCutscene(true);
    }

    
    
}
