using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DynamicUI : MonoBehaviour
    {
        [SerializeField] private GameObject UI;
        private bool isActive = false;

        private void Start()
        {
            disableUI();
        }

        public void setActive()
        {
            isActive = true;
            enableUI();
        }
        
        public void enableUI()
        {
            if (isActive)
            {
                UI.SetActive(true);
            }
        }

        public void disableUI()
        {
            UI.SetActive(false);
        }
    }
}