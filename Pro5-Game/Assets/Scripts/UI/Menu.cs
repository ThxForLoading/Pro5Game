using System;
using UnityEngine;
using UnityEngine.UI;
using Whilefun.FPEKit;

namespace UI
{
    public class Menu : FPEMenu
    {

        public static Menu Instance;
        
        [SerializeField] private Button settings;
        [SerializeField] private Button controlls;
        [SerializeField] private Button exitGame;
        
        [SerializeField] private GameObject settingsTab;

        [SerializeField] private GameObject controllsTab;
        [SerializeField] private GameObject menuTab;
        [SerializeField] private GameObject menuTabStartMenu;

        [SerializeField] private GameObject startMenu;
        [SerializeField] private GameObject pauseMenu;
        
        private MenuState menuState = MenuState.startMenu;
        FPEInteractionManagerScript interactionManager;
        
        //To Do
        
        
        
        private void Awake()
        {
            base.Awake();
            interactionManager = FPEInteractionManagerScript.Instance;
            pauseMenu.SetActive(false);
            

            
            if (Instance != null && Instance != this) 
            {
                throw new Exception("There can only be one instance of PauseMenu!");
            } 
            else 
            { 
                Instance = this; 
            }
            
        }

        private void Start()
        {
            interactionManager.openMenu();
            deactivateAllTabs();
            print("Mouse Sensitivity: " + FPEInputManager.Instance.LookSensitivity);
        }


        public enum ButtonType
        {
            Settings,
            Controls,
            ExitGame,
            Back,
            StartGame,
            CloseGame
        }

        public enum MenuState
        {
            startMenu,
            pauseMenu,
            None
        }
    
        public override void activateMenu()
        {
            if (menuState != MenuState.startMenu)
            {
                pauseMenu.SetActive(true);
                menuTab.SetActive(true);
                
                menuState = MenuState.pauseMenu;
            }
        }

        public override void deactivateMenu()
        {
            if (menuState != MenuState.startMenu)
            {
                pauseMenu.SetActive(false);
                deactivateAllTabs();
                menuState = MenuState.None;
            }
        }



        public void buttonPressed(ButtonType type)
        {
            switch (type)
            {
                case ButtonType.Settings:
                    if (menuState == MenuState.startMenu)
                    {
                        settingsTab.SetActive(true);
                        menuTabStartMenu.SetActive(false);
                    }
                    else if(menuState == MenuState.pauseMenu)
                    {
                        settingsTab.SetActive(true);
                        menuTab.SetActive(false);
                    }
                    break;
                case ButtonType.Controls:
                    // show controls
                    controllsTab.SetActive(true);
                    menuTab.SetActive(false);
                    break;
                case ButtonType.ExitGame:
                    // exit game
                    pauseMenu.SetActive(false);
                    startMenu.SetActive(true);
                    break;
                case ButtonType.Back:
                    deactivateAllTabs();
                    if (menuState == MenuState.startMenu)
                    {
                        menuTabStartMenu.SetActive(true);
                    }
                    else if(menuState == MenuState.pauseMenu)
                    {
                        menuTab.SetActive(true);
                    }

                    break;
                case ButtonType.CloseGame:
                    #if UNITY_EDITOR
                            UnityEditor.EditorApplication.isPlaying = false;
                    #else
                            Application.Quit();
                    #endif
                    break;
                case ButtonType.StartGame:
                    interactionManager.closeMenu();
                    startMenu.SetActive(false);
                    menuState = MenuState.None;
                    break;
            }
        }
        
        private void deactivateAllTabs()
        {
            settingsTab.SetActive(false);
            controllsTab.SetActive(false);
        }
        
        // change sensitivity
        // FPEInteractionManagerScript.Instance.changeMouseSensitivityFromMenu(changedSensitivity);
        
        // change volume
        
        // change music volume
        
        
    
    
    }
}
