using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Whilefun.FPEKit;

public class MenuSlider : MonoBehaviour
{
    [SerializeField] private SliderType sliderType;
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 1f;
    private float defaultValue = 0.5f;
    
    private Slider slider;
    private float curVal;
    
    private enum SliderType
    {
        GameVolume,
        MusicVolume,
        MouseSensitivity
    }
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.value = defaultValue;
        curVal = defaultValue;
    }

    void Update()
    {
        if (slider.value != curVal)
        {
            curVal = slider.value;
            
            switch (sliderType)
            {
                case SliderType.GameVolume:
                    print("Game Volume: " + curVal);
                    break;
                case SliderType.MusicVolume:
                    print("Music Volume: " + curVal);
                    break;
                case SliderType.MouseSensitivity:
                    //print("Mouse Sensitivity: " + FPEInputManager.Instance.LookSensitivity);
                    float sensitivity = curVal * maxValue + ( 1 - curVal ) * minValue;
                    FPEInteractionManagerScript.Instance.changeMouseSensitivityFromMenu(sensitivity);
                    break;
            }
        }
    }


}
