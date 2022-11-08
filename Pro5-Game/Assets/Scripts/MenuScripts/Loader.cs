using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public enum Scenes
    {
        InGame,
        Loading,
        MainMenu,
        OptionsMenu,
        OptionsMenuIngame,
    }

    private static Action onLoaderCallback;

    public static void Load(Scenes scene)
    {
        onLoaderCallback = () =>
        {
            SceneManager.LoadSceneAsync(scene.ToString());
        };
        SceneManager.LoadScene(Scenes.Loading.ToString());
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
