using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene2 : MonoBehaviour
{
    public int wait;
    public GameObject Load;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Loading", wait - 3);
        Invoke("Next", wait);

    }

    void Loading()
    {
        Load.SetActive(true);
    }

    void Next()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
