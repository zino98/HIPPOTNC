using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    private float length;

    private GameObject Object;

    private void Start()
    {
        Object = GameObject.Find("Sound Manager");
        length = Object.GetComponent<SoundManager>().audioSource.clip.length;

        this.gameObject.SetActive(false);

        Invoke("Go", length);
    }

    private void Go()
    {
        this.gameObject.SetActive(true);
    }

   
}
