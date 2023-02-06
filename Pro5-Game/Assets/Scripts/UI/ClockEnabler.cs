using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockEnabler : MonoBehaviour
{
    public bool clock;
    public bool hint = true;
    [SerializeField] GameObject UIClock;
    [SerializeField] GameObject UIHint;
    GameObject voicePlayer;

    // Start is called before the first frame update
    void Start()
    {
        voicePlayer = GameObject.FindGameObjectWithTag("VoicePlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (clock)
        {
            UIClock.SetActive(true);
            if (hint)
            {
                ShowClockHint();
                hint = false;
            }
        }
    }

    public void setClockActive()
    {
        clock = true;
    }

    public void ShowClockHint()
    {
        StartCoroutine(ShowHint());
    }

    private IEnumerator ShowHint()
    {
        UIHint.SetActive(true);
        voicePlayer.GetComponent<VoicePlayer>().PlayClockTimeTravelStories();
        yield return new WaitForSeconds(5.0f);

        UIHint.SetActive(false);
    }
}
