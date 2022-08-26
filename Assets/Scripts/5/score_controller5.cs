using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;
using System.Collections;
using UnityEngine.SceneManagement;

public class score_controller5 : MonoBehaviour
{
    public GameObject[] detects;
    public GameObject time;
    public int containerNum;
    public double totalScore;
    public int totalAttempt;
    private double finalscore;

    string filename = "";
    bool is_updated;

    private void Awake()
    {
        filename = Application.dataPath + "/Score.csv";
    }

    void OnTriggerEnter(Collider other)
    {
            totalScore += Score(other);
            totalAttempt += 1;
            Debug.Log(totalAttempt);
            Debug.Log(totalScore);
            for (int i = 0; i < detects.Length; ++i)
            {
                detects[i].GetComponent<score_controller5>().totalScore = totalScore;
                detects[i].GetComponent<score_controller5>().totalAttempt = totalAttempt;
            }

            disable_Xr(other);
    }

    void Update()
    {
        if (!is_updated && time.GetComponent<time_controller>().is_timeover == true)
        {
            is_updated = true;
            for (int i = 0; i < detects.Length; ++i)
            {
                detects[i].GetComponent<score_controller5>().is_updated = true;
            }
            time.GetComponent<time_controller>().audio.GetComponent<audio_controller>().playsecond(); // edit
            //scoring
            Calculate();
            //Debug.Log(Calculate());
            TextWriter tw = new StreamWriter(filename, true);
            double check = finalscore;
            tw.WriteLine("4, " + finalscore);
            tw.Close();

            StartCoroutine(Seq());
            Debug.Log("end of Scene5 - attempt over");
        }
    }

    public void disable_Xr(Collider other)
    {
        other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
    }

    public double Score(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("A") && containerNum == 1)
        {
            Debug.Log("CorrectA");
            return 2.5;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("B") && containerNum == 2)
        {
            Debug.Log("CorrectB");
            return 2.5;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("C") && containerNum == 3)
        {
            Debug.Log("CorrectC");
            return 2.5;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("D") && containerNum == 4)
        {
            Debug.Log("CorrectD");
            return 2.5;
        }
        Debug.Log("Wrong");
        return 0;
    }

    public void Calculate()
    {
        float timee = time.GetComponent<time_controller>().setTime;

        if (40 <= timee && timee < 60)
            finalscore = totalScore * 0.6;

        else if (20 <= timee && timee < 40)
            finalscore = totalScore * 0.8;

        else if (0 < timee && timee < 20)
            finalscore = totalScore;

        else
            finalscore = totalScore * 0.4;

    }

    IEnumerator beforescenechange()
    {
        time.GetComponent<time_controller>().audio.GetComponent<audio_controller>().playsecond();
        yield return new WaitForSeconds(10f);
    }

    IEnumerator fadescene()
    {
        time.GetComponent<time_controller>().fadecanvas.GetComponent<fade_controller>().StartFadeIn();
        yield return new WaitForSeconds(1f);
        time.GetComponent<time_controller>().loadcanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Seq()
    {
        yield return StartCoroutine(beforescenechange());
        yield return StartCoroutine(fadescene());
        yield return StartCoroutine(nextScene());
    }

}
