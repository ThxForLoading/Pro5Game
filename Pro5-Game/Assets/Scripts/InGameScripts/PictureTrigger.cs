using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureTrigger : MonoBehaviour
{
    [SerializeField] GameObject voiceplayer;
    bool lookedAlready = true;

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
        if (lookedAlready)
        {
            if (other.tag == "Player")
            {
                voiceplayer.GetComponent<VoicePlayer>().PlayOhItsAlbert();
            }
            lookedAlready = false;
        }

    }
}
