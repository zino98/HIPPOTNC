using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnAudio : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    public void TurnAudio()
    {
        audioSource.Play();
    }

    
}
