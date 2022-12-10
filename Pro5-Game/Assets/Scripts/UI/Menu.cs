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
        
        
        // Inventory stuff
        private FPEInventoryItemSlot[] inventorySlots = null;
        private FPEInventoryItemData[] itemData = null;
        private FPEInventoryItemInfoPanel itemInfoPanel = null;
        private GameObject inventoryTab = null;
        
        private Canvas inventoryCanvas;
        private GameObject inventoryItemInfoPanelParent = null;
        private MenuState menuState = MenuState.startMenu;
        FPEInteractionManagerScript interactionManager;
        
        // Page Stuff
        // Page selection buttons and gamepad hints
        private GameObject previousPageButton = null;
        private GameObject nextPageButton = null;
        private GameObject previousPageHint = null;
        private GameObject nextPageHint = null;
        private Text pageIndicatorText = null;



        private void Awake()
        {
            base.Awake();
            interactionManager = FPEInteractionManagerScript.Instance;
            pauseMenu.SetActive(false);
            
            
            // Inventory stuff
            inventoryCanvas = GetComponentInChildren<Canvas>();
            if (inventoryCanvas == null)
            {
                Debug.LogError("FPEInventoryManager: No Canvas found in children of this GameObject!");
            }
            
            inventoryItemInfoPanelParent = inventoryCanvas.gameObject.transform.Find("InventoryItemInfoPanel").gameObject;
            if (inventoryItemInfoPanelParent == null)
            {
                Debug.LogError("FPEInventoryManager: No InventoryItemInfoPanel found in children of this GameObject!");
            }
            
            inventorySlots = GetComponentsInChildren<FPEInventoryItemSlot>();
            if (inventorySlots == null)
            {
                Debug.LogError("Menu: No inventory slots found!");
            }
            
            
            
            //updateInventorySlots();
            //clearItemDetails();
            inventoryItemInfoPanelParent = inventoryCanvas.gameObject.transform.Find("InventoryItemInfoPanel").gameObject;
            itemInfoPanel = inventoryItemInfoPanelParent.GetComponent<FPEInventoryItemInfoPanel>();
            

            if (itemInfoPanel == null)
            {
                Debug.LogError("Menu: No item info panel found!");
            }

            
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

        // public void updateInventorySlots()
        // {
        //     // FPEInventoryItemData[] data = FPEInventoryManagerScript.Instance.getInventoryData();
        //     // for (int i = 0; i < inventorySlots.Length; i++)
        //     // {
        //     //     if (i < data.Length)
        //     //     {
        //     //         inventorySlots[i].setItemData(i, data[i]);
        //     //     }
        //     //     else
        //     //     {
        //     //         inventorySlots[i].setItemData(i, null);
        //     //     }
        //     // }
        //     
        //     itemData = FPEInventoryManagerScript.Instance.getInventoryData();
        //
        //     if (itemData.Length == 0)
        //     {
        //         itemInfoPanel.clearItemDetails();
        //     }
        // }
        
        // private void clearItemDetails()
        // {
        //     foreach(FPEInventoryItemSlot slot in inventorySlots)
        //     {
        //         slot.clearItemData();
        //     }
        // }
        
        public void updateItemDataView(int itemIndex, bool playAudio = true)
        {
            print("updateItemDataView");
            int actualItemIndex = itemIndex; //+ (previouslySelectedPage[(int)eMenuTab.ITEMS] * itemsPerPage[(int)eMenuTab.ITEMS]);

            if (actualItemIndex < 0 || actualItemIndex > itemData.Length)
            {
                Debug.LogError("FPEGameMenu.updateItemDataView() given bad itemIndex of '" + actualItemIndex + "'. Cannot retrieve item data!");
            }
            else
            {

                // Manually unhighlight all slots that are not the calling slot, because Unity UI using mouseovers is tricky sometimes apparently
                for (int s = 0; s < inventorySlots.Length; s++)
                {
                    if (inventorySlots[s].CurrentInventoryDataIndex != itemIndex)
                    {
                        inventorySlots[s].ForceUnhighlight();
                    }
                }

                itemInfoPanel.setItemDetails(itemData[actualItemIndex]);

                if (playAudio)
                {
                    //menuAudio.PlayOneShot(menuSelect);
                }

            }
        }
        
        
        // public void moveToPreviousPage()
        // {
        //
        //     if (previouslySelectedPage[(int)currentMenuTab] > 0)
        //     {
        //         previouslySelectedPage[(int)currentMenuTab] -= 1;
        //         menuAudio.PlayOneShot(menuPageTurn);
        //         refreshPage();
        //     }
        //
        // }
        //
        // public void moveToNextPage()
        // {
        //
        //     int maxPageNumber = getMaxPagesForTab();
        //
        //     if ((previouslySelectedPage[(int)currentMenuTab] + 1) < maxPageNumber)
        //     {
        //         previouslySelectedPage[(int)currentMenuTab] += 1;
        //         menuAudio.PlayOneShot(menuPageTurn);
        //         refreshPage();
        //     }
        //
        // }
        // private void selectItemPage(int pageNumber)
        // {
        //
        //     int maxPageNumber = getMaxPagesForTab();
        //
        //     if(pageNumber >= maxPageNumber)
        //     {
        //         previouslySelectedPage[(int)eMenuTab.ITEMS] = maxPageNumber-1;
        //     }
        //     else
        //     {
        //         previouslySelectedPage[(int)eMenuTab.ITEMS] = pageNumber;
        //     }
        //
        //     for (int i = 0; i < inventorySlots.Length; i++)
        //     {
        //
        //         if ((i + (previouslySelectedPage[(int)eMenuTab.ITEMS] * itemsPerPage[(int)eMenuTab.ITEMS])) < itemData.Length)
        //         {
        //
        //             inventorySlots[i].setItemData(i, itemData[i + (previouslySelectedPage[(int)eMenuTab.ITEMS] * itemsPerPage[(int)eMenuTab.ITEMS])]);
        //
        //             // If its the first slot, set the detailed info panel based on the item in that first slot
        //             if (i == 0)
        //             {
        //                 itemInfoPanel.setItemDetails(itemData[i + (previouslySelectedPage[(int)eMenuTab.ITEMS] * itemsPerPage[(int)eMenuTab.ITEMS])]);
        //             }
        //
        //         }
        //         else
        //         {
        //             inventorySlots[i].clearItemData();
        //         }
        //
        //     }
        //
        //     refreshPageHintsUI(previouslySelectedPage[(int)eMenuTab.ITEMS]);
        //
        // }
        //
        // private void refreshPageHintsUI(int pageNumber)
        // {
        //
        //     int maxPageNumber = getMaxPagesForTab();
        //     pageIndicatorText.text = "Page " + (pageNumber + 1) + "/" + maxPageNumber;
        //
        //     // If we have 1 page, disable all buttons
        //     if (maxPageNumber == 1)
        //     {
        //
        //         previousPageButton.GetComponent<FPEMenuButton>().disableButton();
        //         nextPageButton.GetComponent<FPEMenuButton>().disableButton();
        //         previousPageHint.SetActive(false);
        //         nextPageHint.SetActive(false);
        //
        //         if(itemData.Length == 0)
        //         {
        //             pageIndicatorText.text = "Page -/-";
        //         }
        //
        //     }
        //     // If we have more than one, and are on the first page, only enable next button
        //     else if (maxPageNumber > 1 && pageNumber == 0)
        //     {
        //
        //         previousPageButton.GetComponent<FPEMenuButton>().disableButton();
        //         nextPageButton.GetComponent<FPEMenuButton>().enableButton();
        //         previousPageHint.SetActive(false);
        //         nextPageHint.SetActive(true);
        //
        //     }
        //     // If we have more than one, and are not on that one, enable both buttons
        //     else if (maxPageNumber > 1 && pageNumber != (maxPageNumber-1))
        //     {
        //
        //         previousPageButton.GetComponent<FPEMenuButton>().enableButton();
        //         nextPageButton.GetComponent<FPEMenuButton>().enableButton();
        //         previousPageHint.SetActive(true);
        //         nextPageHint.SetActive(true);
        //
        //     }
        //     // If we have more than one, and are on last page, only enable previous button
        //     else if (maxPageNumber > 1 && pageNumber == (maxPageNumber - 1))
        //     {
        //
        //         previousPageButton.GetComponent<FPEMenuButton>().enableButton();
        //         nextPageButton.GetComponent<FPEMenuButton>().disableButton();
        //         previousPageHint.SetActive(true);
        //         nextPageHint.SetActive(false);
        //
        //     }
        //     else
        //     {
        //         Debug.LogError("FPEGameMenu.refreshPageHintsUI():: Encountered bad combination of number of inventory items and max pages for '"+currentMenuTab+"' tab. Prev/Next page buttons won't work.");
        //     }
        //
        // }
        
        public void clearItemDataView()
        {
            itemInfoPanel.clearItemDetails();
        }
        
        
        
        
        // change sensitivity
        // FPEInteractionManagerScript.Instance.changeMouseSensitivityFromMenu(changedSensitivity);
        
        // change volume
        
        // change music volume
    }
}
