using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleHelper : MonoBehaviour
{
    [SerializeField] private float delay = 60f;

    private ParticleSystem particles;

    private bool particlesStopped = false;

    void Start()
    {
        particles = GetComponentInParent<ParticleSystem>();
        StartCoroutine(playParticles());
    }

    IEnumerator playParticles()
    {
        yield return new WaitForSeconds(delay);
        if (!particlesStopped)
        {
            particles.Play();
        }
        
    }

    public void stopParticles()
    {
        particles.Stop();
        particlesStopped = true;
    }

}
