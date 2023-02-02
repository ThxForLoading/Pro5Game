using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip oldHouseAudio;
    public AudioClip newHouseAudio;
    public float maxVolume = 0.5f;

    private AudioSource track01, track02;
    private bool isPlayingTrack01;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        track01 = gameObject.AddComponent<AudioSource>();
        track01.loop = true;
        track02 = gameObject.AddComponent<AudioSource>();
        track02.loop = true;
        isPlayingTrack01 = true;

        SwapTrack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapTrack()
    {
        AudioClip newClip;
        if (isPlayingTrack01)
        {
            newClip = newHouseAudio;
        }
        else
        {
            newClip = oldHouseAudio;
        }

        StopAllCoroutines();

        StartCoroutine(FadeTrack(newClip));

        isPlayingTrack01 = !isPlayingTrack01;
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeFade = 2.25f;
        float timeElapsed = 0;
        if (isPlayingTrack01)
        {
            newClip = newHouseAudio;
        }
        else
        {
            newClip = oldHouseAudio;
        }


        if (isPlayingTrack01)
        {
            track02.clip = newClip;
            track02.Play();

            while (timeElapsed < timeFade)
            {
                track02.volume = Mathf.Lerp(0, maxVolume, timeElapsed / timeFade);
                track01.volume = Mathf.Lerp(maxVolume, 0, timeElapsed / timeFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            track01.Stop();
        }
        else
        {
            track01.clip = newClip;
            track01.Play();
            while (timeElapsed < timeFade)
            {
                track01.volume = Mathf.Lerp(0, maxVolume, timeElapsed / timeFade);
                track02.volume = Mathf.Lerp(maxVolume, 0, timeElapsed / timeFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track02.Stop();
        }
    }
}
