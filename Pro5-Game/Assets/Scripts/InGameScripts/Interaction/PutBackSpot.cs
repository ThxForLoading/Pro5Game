using System;
using UnityEngine;
using Whilefun.FPEKit;


public class PutBackSpot : FPEPutBackScript
{

    [SerializeField] private String tagName;
    [SerializeField] protected int placementID;
    [SerializeField] protected RiddleHelper riddleHelper;
    protected  PutBackBehaviour putBackBehaviour;

    protected bool correctPlacement = false;
    
    private void Start()
    {
        PutBackBehaviour[] allbehaviours = FindObjectsOfType<PutBackBehaviour>();
        // find behaviour with the same tag
        foreach (PutBackBehaviour behaviour in allbehaviours)
        {
            if (behaviour.CompareTag(tagName))
            {
                putBackBehaviour = behaviour;
                return;
            }
        }

        Debug.Log("No behaviour found with tag " + tagName);
    }
    public override bool putBackMatchesGameObject(GameObject go)
    {
        // check if go has tag MonkeyStatue
        if (go.CompareTag(tagName))
        {
            return true;
        }
        return false;
    }
    
    // setter and getter for correctPacement
    public virtual void PlaceObject(int objID)
    {
        if (riddleHelper != null) riddleHelper.stopParticles();
        
        if (objID == placementID)
        {
            correctPlacement = true;
            putBackBehaviour.CheckConditions();
        }
        else
        {
            correctPlacement = false;
        }
        
    }
    public bool GetCorrectPlacement()
    {
        return correctPlacement;
    }
    
    
    
}
