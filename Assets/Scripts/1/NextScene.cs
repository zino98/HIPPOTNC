using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject Load;

    public void NextS()
    {
        Load.SetActive(true);
        Invoke("Next", 2f);
        Invoke("N", 3f);
    }

    void Next()
    {
        Load.SetActive(false);
    }

    void N()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}




