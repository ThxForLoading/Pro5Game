using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;


public class Oven : PutBackBehaviour
{

    private bool ovenTurneOn = false;

    public override void CheckConditions()
    {
        // if all putBackspots getCorrectPlacement is true 
        foreach (PutBackSpot spot in putBackSpots)
        {
            if (!spot.GetCorrectPlacement())
            {
                return;
            }
        }

        if (ovenTurneOn)
        {
            ExecuteBehaviour();
        }
        
        
        
    }

    public void turnOnOven()
    {
        ovenTurneOn = true;
    }
    
}
