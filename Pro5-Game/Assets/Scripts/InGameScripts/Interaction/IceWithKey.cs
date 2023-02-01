using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;


public class IceWithKey : PutBackPickup
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject keyView;
    [SerializeField] private GameObject ice;

    public void removeIce()
    {
        Destroy(ice);
        Destroy(keyView);
        key.SetActive(true);
    }

    public void disablePhysics()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Collider>().enabled = false;
    }
}
