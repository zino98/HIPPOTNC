using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextQuestion4 : MonoBehaviour
{
    public GameObject now;
    public GameObject next;
    public GameObject Load;
    public float time;

    //GameObject my;
    // Start is called before the first frame update
    public void Wait()
    {
        Invoke("Next", time);
    }
    public void Next()
    {
        /*my = GetComponent<GameObject>();
        my.SetActive(false);*/
        now.SetActive(false);
        Load.SetActive(true);
        
        Invoke("OffLoad", 5f);
        Invoke("New", 5f);
        
    }

    void New()
    {
        next.SetActive(true);
    }

    void OffLoad()
    {
        Load.SetActive(false);
    }

}
