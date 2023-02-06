using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPot : PutBackSpot
{
    public override void PlaceObject(int objID)
    {
        if (objID == placementID)
        {
            if (riddleHelper != null) riddleHelper.stopParticles();
            correctPlacement = true;
            putBackBehaviour.CheckConditions();
            GetComponent<SphereCollider>().enabled = false;
        }
        else
        {
            correctPlacement = false;
        }
        
    }
    
}
