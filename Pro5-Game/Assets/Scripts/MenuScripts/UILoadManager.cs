using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoadManager : MonoBehaviour
{

    public void LoadGame()
    {
        Loader.Load(Loader.Scenes.InGame);
    }

    public void LoadMain()
    {
        Loader.Load(Loader.Scenes.MainMenu);
    }

    public void LoadOptions()
    {
        Loader.Load(Loader.Scenes.OptionsMenu);
    }

    public void LoadOptionsIngame()
    {
        Loader.Load(Loader.Scenes.OptionsMenuIngame);
    }

    public void LeaveGame()
    {
        Application.Quit();
        Debug.Log("Left Game");
    }
}
