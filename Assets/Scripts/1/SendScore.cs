using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SendScore : MonoBehaviour
{
    public GameObject socket;
    public GameObject Excel;
    public int currentQ;
    
    public int[] score_list;
    float score;


    public void Send()
    {
        

        ScoreOne s = socket.GetComponent<ScoreOne>();
        score_list = s.correct;
        score = (score_list.Sum() * 4) / 3f;
        score = Mathf.Round(score * 100) * 0.01f;
        Debug.Log(score);
        Excel.GetComponent<score_controller1>().totaladder(score);
    }
    


}
