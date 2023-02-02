using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TriggerEndScene : MonoBehaviour
{
    public static TriggerEndScene instance;
    [SerializeField] Sprite[] Intro;
    [SerializeField] Sprite[] Fight;
    [SerializeField] Sprite[] ChoiceA;
    [SerializeField] Sprite[] ChoiceB;
    [SerializeField] Sprite Decision;

    [SerializeField] GameObject Background;
    [SerializeField] GameObject SlideHolder;
    [SerializeField] UnityEngine.UI.Image Slide;
    [SerializeField] GameObject ChoiceUI;

    private bool choice = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startEnding()
    {
        Background.SetActive(true);
        Slide.sprite = Intro[0];
        SlideHolder.SetActive(true);
        Debug.Log("End is now");
        //CODE ENDING SEQUENCE HERE
        StartCoroutine(PlayEnding());
    }

    private IEnumerator PlayEnding()
    {
        AudioManager.instance.PlayEndingIntro();
        if (AudioManager.instance.isPlayingTrack01)
        {
            yield return new WaitWhile(() => AudioManager.instance.track01.isPlaying);
        }
        else
        {
            yield return new WaitWhile(() => AudioManager.instance.track02.isPlaying);
        }

        yield return new WaitForSeconds(3.5f);

        AudioManager.instance.PlayEndingFight();
        if (AudioManager.instance.isPlayingTrack01)
        {
            yield return new WaitWhile(() => AudioManager.instance.track01.isPlaying);
        }
        else
        {
            yield return new WaitWhile(() => AudioManager.instance.track02.isPlaying);
        }


        ChoiceUI.SetActive(true);
        yield return waitForKeyPress();
        if (Input.mousePosition.x > Screen.width/2)
        {
            choice = false;
        }
        else
        {
            choice = true;
        }
        ChoiceUI.SetActive(false);

        if (choice)
        {
            AudioManager.instance.PlayEndingChoiceA();
            if (AudioManager.instance.isPlayingTrack01)
            {
                yield return new WaitWhile(() => AudioManager.instance.track01.isPlaying);
            }
            else
            {
                yield return new WaitWhile(() => AudioManager.instance.track02.isPlaying);
            }
        }
        else
        {
            AudioManager.instance.PlayEndingChoiceB();
            if (AudioManager.instance.isPlayingTrack01)
            {
                yield return new WaitWhile(() => AudioManager.instance.track01.isPlaying);
            }
            else
            {
                yield return new WaitWhile(() => AudioManager.instance.track02.isPlaying);
            }
        }
    }

    private IEnumerator waitForKeyPress()
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetMouseButtonDown(0))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }

    private IEnumerator showIntro()
    {
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator showFight()
    {
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator showChoiceA()
    {
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator showChoiceB()
    {
        yield return new WaitForSeconds(0.5f);
    }

}