using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorLockedCollider : MonoBehaviour
{
    [SerializeField] GameObject voiceplayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            voiceplayer.GetComponent<VoicePlayer>().PlayItsLockedPast();   
        }
    }
}
