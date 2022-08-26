using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Disappear : MonoBehaviour
{
    public GameObject my;
    public GameObject button;
    public float time;
    public TextMeshPro countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = GetComponent<TextMeshPro>();
        countdown.text = time.ToString();
           
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Diss();
        }

        countdown.text = Mathf.Round(time).ToString();
    }
    void Diss()
    {
        my.SetActive(false);
        button.SetActive(true);
    }
}
