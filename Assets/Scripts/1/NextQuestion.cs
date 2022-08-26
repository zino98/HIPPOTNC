using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextQuestion : MonoBehaviour
{
    public GameObject now;
    public GameObject next;
    public GameObject Load;
  
   
    
    // Start is called before the first frame update

    
    public void NextQ()
    {
        now.SetActive(false);
        Load.SetActive(true);

        Invoke("OffLoad", 2.5f);
        Invoke("New", 2.5f);
        
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
