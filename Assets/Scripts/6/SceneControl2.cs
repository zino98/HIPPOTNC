using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl2 : MonoBehaviour
{
    private AudioSource audioSource;

    private float length;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        length = audioSource.clip.length;

        Play();
    }

    private void Play()
    {
        audioSource.Play();
        Invoke("Go", length);
    }

    private void Go()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
