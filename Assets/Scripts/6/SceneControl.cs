using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

    public GameObject loadcanvas;

    public void Go()
    {
        StartCoroutine(seq());
    }

    IEnumerator loading()
    {
        yield return null;
        loadcanvas.gameObject.SetActive(true);
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator seq()
    {
        yield return StartCoroutine(loading());
        yield return StartCoroutine(nextScene());
    }
}
