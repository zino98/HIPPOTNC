using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    private bool play;

    private float playTime;

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        playTime = audioSource.clip.length;

        Play();

    }

    private void Update()
    {
        play = audioSource.isPlaying;
        
    }

    private void Play()
    {
        audioSource.Play();

        Invoke("Stop", playTime);
    }

    private void Stop()
    {
        audioSource.Pause();
    }

}
