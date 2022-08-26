using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next_7 : MonoBehaviour
{
    public GameObject now;
    public GameObject next;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Next", time);    
    }

    void Next()
    {
        now.SetActive(false);
        next.SetActive(true);
    }
}
