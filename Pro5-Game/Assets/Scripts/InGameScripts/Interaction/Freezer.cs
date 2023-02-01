using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;


public class Freezer : FPEInteractableActivateScript
{
    [SerializeField] private GameObject lidOpen;
    [SerializeField] private GameObject lidClosed;
    
    public void removeLid()
    {
        Destroy(lidClosed);
        lidOpen.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
    }   
}
