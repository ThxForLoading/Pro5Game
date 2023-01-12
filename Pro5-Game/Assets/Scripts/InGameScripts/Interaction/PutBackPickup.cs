using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class PutBackPickup : FPEInteractablePickupScript
{
    [SerializeField] private int placementID;
    
    // get placementID
    public int GetPlacementID()
    {
        return placementID;
    }
}
