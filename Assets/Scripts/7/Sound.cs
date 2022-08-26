using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audiosource;


    public void PlayAudio()
    {
        audiosource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 20)
        {
            audiosource.Play();
        }
    }
}
