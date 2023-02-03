using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableWall : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject overlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnKey()
    {
        Debug.Log("Spawn Key");
        Instantiate(prefab, spawn.transform);
        overlay.SetActive(true);
        GetComponent<Collider>().enabled = false;
    }

    public void NoReaction()
    {
        Debug.Log("Nothing happened");
    }
}
