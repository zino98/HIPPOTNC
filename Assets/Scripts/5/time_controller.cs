using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class time_controller : MonoBehaviour
{
    public int timespent;
    public bool is_timeover;
    public bool is_played;
    public float setTime = 0;
    public TextMesh countdownText;
    public GameObject audio;
    public GameObject detect;
    public GameObject fadecanvas;
    public GameObject loadcanvas;

    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<TextMesh>();
        countdownText.text = setTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.GetComponent<audio_controller>().is_finished == true)
        {
            if (setTime < 60)
            {
                setTime += Time.deltaTime;
            }

            countdownText.text = Mathf.Round(setTime).ToString();

            if (setTime > 60 && is_timeover == false)
            {
                is_timeover = true;
            }
        }
    }

    public void pressed()
    {
        is_timeover = true;
    }
}