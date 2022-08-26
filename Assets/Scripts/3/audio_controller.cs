using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_controller : MonoBehaviour
{
    public AudioSource source;
    public AudioClip bell;
    public AudioClip[] first;
    public AudioClip[] second;
    public AudioClip[] third;
    public bool is_finished;

    public void ring()
    {
        source.clip = bell;
        source.Play();
    }

    public void playfirst()
    {
        StartCoroutine(playAudioSequentially(first, 1));
    }

    public void playsecond()
    {
        StartCoroutine(playAudioSequentially(second, 2));
    }

    public void playthird()
    {
        StartCoroutine(playAudioSequentially(third, 3));
    }

    IEnumerator playAudioSequentially(AudioClip[] which, int num)
    {
        if (num == 1)
        {
            yield return new WaitForSeconds(5f);
        }

        for (int i = 0; i < which.Length; i++)
        {
            source.clip = which[i];
            source.Play();

            while (source.isPlaying)
            {
                yield return null;
            }
        }

        if (num == 1)
        {
            yield return new WaitForSeconds(1f);
            is_finished = true;
        }
        
    }

}
