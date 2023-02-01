using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Whilefun.FPEKit;

public class PutBackBehaviour : MonoBehaviour
{
    protected List<PutBackSpot> putBackSpots = new List<PutBackSpot>();
    [SerializeField] private String tagName;
    [SerializeField] private FPEGenericEvent behaviour;

    private void Start()
    {
        // find objects with tagname
        PutBackSpot[] allSpots = FindObjectsOfType<PutBackSpot>();

        foreach (PutBackSpot spot in allSpots)
        {
            if (spot.CompareTag(tagName))
            {
                // add to list
                putBackSpots.Add(spot);
            }
        }

    }


    public virtual void CheckConditions()
    { 
        // if all putBackspots getCorrectPlacement is true 
        foreach (PutBackSpot spot in putBackSpots)
        {
            if (!spot.GetCorrectPlacement())
            {
                return;
            }
        }
        ExecuteBehaviour();
    }
    
    protected void ExecuteBehaviour()
    {
        print("execute behaviour");
        behaviour.Invoke();

    }
}
