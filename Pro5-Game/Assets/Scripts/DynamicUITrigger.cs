using System;
using UnityEngine;
using Whilefun.FPEKit;

namespace DefaultNamespace
{
    public class DynamicUITrigger : MonoBehaviour
    {
        [SerializeField] private DynamicUI dynamicUI;
        private Collider col;

        private void Start()
        {
            col = GetComponent<Collider>();
        }
        

        private void OnTriggerEnter(Collider other)
        {
            print("Trigger");
            if (other.gameObject.GetComponent <FPEFirstPersonController>() != null)
            {
                print("Player enter");
                dynamicUI.enableUI();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            print("Trigger exit");
            if (other.gameObject.GetComponent <FPEFirstPersonController>() != null)
            {
                print("Player exit");
                dynamicUI.disableUI();
            }
        }

    }
}