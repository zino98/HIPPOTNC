using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class detect_rubbish : MonoBehaviour
{
    public GameObject[] rubbishes;
    public GameObject[] detects;
    public GameObject ScoreManager;
    public new GameObject audio;
    public GameObject fadecanvas;
    public GameObject loadcanvas;

    private string totalScore;
    public int binNumber;
    public int currentQuestion;
    bool isColliding;

    void Awake()
    {
        currentQuestion = 1;
        totalScore = "";
    }

    void OnTriggerEnter(Collider other)
    { // 쓰레기가 네개의 쓰레기통 중 한 곳에 들어가게되면
        for (int i = 0; i < rubbishes.Length; ++i)
        {
            if (other.gameObject.name == rubbishes[i].gameObject.name)
            {
                if (isColliding) return;
                isColliding = true;
                Debug.Log("Goal!");
                int answerBin_Num = GameObject.Find("A").GetComponent<bin_controller>().answerBin;
                if (answerBin_Num + 1 == binNumber)
                {
                    if (currentQuestion != 1) // first question is for practice, so there is no need to add up the score
                    {
                        Debug.Log("Correct!");
                        if (totalScore != "")
                        {
                            totalScore += ",";
                            totalScore += 5;
                        }
                        else
                        {
                            totalScore += 5;
                        }
                    }
                }
                else
                {
                    if (currentQuestion != 1)
                    {
                        Debug.Log("Wrong!");
                        if (totalScore != "")
                        {
                            totalScore += ",";
                            totalScore += 0;
                        }
                        else
                        {
                            totalScore += 0;
                        }
                    }
                }

                // ===============================transit to next question=================================
                currentQuestion += 1; // 쓰레기통 네개 중 하나의 currentQuestion 값을 올리면 나머지 쓰레기통의 currentQuestion의 값을 올려야됨
                for (int j = 0; j < detects.Length; ++j)
                {
                    detects[j].GetComponent<detect_rubbish>().currentQuestion = currentQuestion;
                    detects[j].GetComponent<detect_rubbish>().totalScore = totalScore;
                }

                if (currentQuestion == 2)
                {
                    audio.GetComponent<audio_controller>().playsecond();
                }

                if (currentQuestion == 6) // Last Question
                {
                    ScoreManager.GetComponent<score_controller>().TotalScore(totalScore);
                    StartCoroutine(Seq());
                    break;
                }

                if (currentQuestion < 6)
                {
                    // ===========change all diagram for next question============ 
                    Debug.Log(currentQuestion);
                    GameObject.Find("A").GetComponent<bin_controller>().Transform(GameObject.Find("A").GetComponent<bin_controller>().canvas, currentQuestion);
                    GameObject.Find("Qs").GetComponent<diagram_image>().changeQ(currentQuestion);
                    break;
                }
            }
        }
    }
    IEnumerator beforescenechange()
    {
        audio.GetComponent<audio_controller>().playthird();
        yield return new WaitForSeconds(15f);
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator fadescene()
    {
        fadecanvas.GetComponent<fade_controller>().StartFadeIn();
        yield return new WaitForSeconds(1f);
        loadcanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);

    }

    IEnumerator Seq()
    {
        yield return StartCoroutine(beforescenechange());
        yield return StartCoroutine(fadescene());
        yield return StartCoroutine(nextScene());
    }

    void Update()
    {
        isColliding = false;
    }
}
  