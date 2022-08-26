using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSound : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject Loading;

    private float length;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        length = audioSource.clip.length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("End");
            Loading.SetActive(true);
            audioSource.Play();
        }

        Invoke("SceneManage", length);
    }

    private void SceneManage()
    {
        SceneManager.LoadScene(3);
    }
}
