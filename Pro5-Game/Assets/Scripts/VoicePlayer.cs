using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VoicePlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] VoiceLines;
    [SerializeField] float Volume = 0.5f;
    public static VoicePlayer instance;
    private AudioSource track01;

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
        track01 = gameObject.AddComponent<AudioSource>();
        track01.volume = Volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPlaceInThePicture()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[0];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayClockTimeTravelStories()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[1];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayWhereWhenAmI()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[2];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayLooksLikeThePicture()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[3];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayOhItsAlbert()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[4];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayREAD()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[5];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayAlbertsPlan()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[6];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayWasThatKitchen()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[7];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayBloodyHellItsCold()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[8];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayAHammer()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[9];
        StartCoroutine(PlayVoiceTrack(newClip));
    }
    public void PlayThatWasKindaIntense()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[10];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayNeverKnewHiddenRoom()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[11];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    public void PlayItsLockedPast()
    {
        StopAllCoroutines();
        AudioClip newClip;
        newClip = VoiceLines[12];
        StartCoroutine(PlayVoiceTrack(newClip));
    }

    private IEnumerator PlayVoiceTrack(AudioClip newClip)
    {
        track01.clip = newClip;
        track01.Play();
        yield return null;
    }
}
