using System;
using UnityEngine;
using UnityEngine.UI;
using Whilefun.FPEKit;

namespace UI
{
    public class PauseMenu : FPEMenu
    {

        public static PauseMenu Instance;
        
        [SerializeField] private Button settings;
        [SerializeField] private Button controlls;
        [SerializeField] private Button exitGame;
        
        [SerializeField] private GameObject settingsTab;
        [SerializeField] private GameObject controllsTab;
        [SerializeField] private GameObject menuTab;
        
        
        
        private void Awake()
        {
            base.Awake();
            if (Instance != null && Instance != this) 
            {
                throw new Exception("There can only be one instance of PauseMenu!");
            } 
            else 
            { 
                Instance = this; 
            }
            this.gameObject.SetActive(false);
        }
        
        public enum ButtonType
        {
            Settings,
            Controls,
            ExitGame,
            Back
        }
    
        public override void activateMenu()
        {
            this.gameObject.SetActive(true);
        }

        public override void deactivateMenu()
        {
            this.gameObject.SetActive(false);
        }



        public void buttonPressed(ButtonType type)
        {
            switch (type)
            {
                case ButtonType.Settings:
                    // show settings
                    settingsTab.SetActive(true);
                    menuTab.SetActive(false);
                    break;
                case ButtonType.Controls:
                    // show controls
                    controllsTab.SetActive(true);
                    menuTab.SetActive(false);
                    break;
                case ButtonType.ExitGame:
                    // exit game
                    print("exit game");
                    break;
                case ButtonType.Back:
                    settingsTab.SetActive(false);
                    controllsTab.SetActive(false);
                    menuTab.SetActive(true);
                    break;
            }
        }
        
        
    
    
    }
}
