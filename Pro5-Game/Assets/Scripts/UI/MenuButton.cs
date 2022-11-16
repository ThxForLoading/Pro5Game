using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PauseMenu.ButtonType buttonType;

    public void OnPointerDown(PointerEventData eventData)
    {
        PauseMenu.Instance.buttonPressed(buttonType);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
