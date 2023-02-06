using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Whilefun.FPEKit;

public class TriggerEndScene : MonoBehaviour
{
    public static TriggerEndScene instance;
    [SerializeField] Sprite[] Intro;
    [SerializeField] Sprite[] Fight;
    [SerializeField] Sprite[] ChoiceA;
    [SerializeField] Sprite[] ChoiceB;
    [SerializeField] Sprite Decision;
    [SerializeField] Sprite Credits;
    [SerializeField] Sprite EndingA;
    [SerializeField] Sprite EndingB;

    [SerializeField] GameObject Background;
    [SerializeField] GameObject SlideHolder;
    [SerializeField] UnityEngine.UI.Image Slide;
    [SerializeField] GameObject ChoiceUI;
    [SerializeField] GameObject leaveGameButton;

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
        FPEInteractionManagerScript.Instance.BeginCutscene(true);
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
        Slide.sprite = Intro[0];
        yield return new WaitForSeconds(4f);
        Slide.sprite = Intro[1];
        yield return new WaitForSeconds(16f);
        Slide.sprite = Intro[2];
        yield return new WaitForSeconds(10f);

        AudioManager.instance.PlayEndingFight();

        Slide.sprite = Fight[0];
        yield return new WaitForSeconds(3f);
        Slide.sprite = Fight[1];
        yield return new WaitForSeconds(5f);
        Slide.sprite = Fight[2];
        yield return new WaitForSeconds(5f);
        Slide.sprite = Fight[3];
        yield return new WaitForSeconds(10f);
        Slide.sprite = Fight[4];
        yield return new WaitForSeconds(3f);
        Slide.sprite = Fight[5];
        yield return new WaitForSeconds(3f);
        Slide.sprite = Fight[6];
        yield return new WaitForSeconds(2f);
        Slide.sprite = Fight[7];
        yield return new WaitForSeconds(3f);

        ChoiceUI.SetActive(true);
        Slide.sprite = Decision;

        yield return waitForKeyPress();
        if (Input.mousePosition.x < Screen.width/2)
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
            Slide.sprite = ChoiceA[0];
            yield return new WaitForSeconds(4f);
            Slide.sprite = ChoiceA[1];
            yield return new WaitForSeconds(28f);
            Slide.sprite = ChoiceA[2];
            yield return new WaitForSeconds(6f);
            Slide.sprite = ChoiceA[3];
            yield return new WaitForSeconds(17f);
            Slide.sprite = EndingA;
            yield return new WaitForSeconds(12f);
            Slide.sprite = Credits;
            leaveGameButton.SetActive(true);
            yield return waitForKeyPress();
            Application.Quit();
        }
        else
        {
            AudioManager.instance.PlayEndingChoiceB();
            Slide.sprite = ChoiceB[0];
            yield return new WaitForSeconds(4f);
            Slide.sprite = ChoiceB[1];
            yield return new WaitForSeconds(11f);
            Slide.sprite = EndingB;
            yield return new WaitForSeconds(12f);
            Slide.sprite = Credits;
            leaveGameButton.SetActive(true);
            yield return waitForKeyPress();
            Application.Quit();

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
}