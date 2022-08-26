using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendScore_7_2 : MonoBehaviour
{
    public List<string> input = new List<string>();
    Transform p;
    int score;
    public float time;
    public int currentQ;
    public GameObject excel;

    private void Start()
    {
        
        score = 0;
        p = gameObject.transform.parent;
        Invoke("CalculateScore", time);
        
        

    }

    private void CalculateScore()
    {
        if (p.name == "Q1")
        {
            if (input.Contains("A"))
            {
                score = 1;
                Debug.Log(score);
            }
        }
        else if (p.name == "Q2")
        {
            if (input.Contains("E"))
            {
                score = 1;
                Debug.Log(score);
            }
        }
        else if (p.name == "Q3")
        {
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == "F" && input[i + 1] == "C")
                {
                    score = 3;
                    Debug.Log(score);
                    break;
                }
            }
            if (score != 3) {
                for (int i = 0; i < input.Count; i++) {
                    if (input.Contains("F"))
                    {
                        score = 1;
                        Debug.Log(score);
                        break;
                    }
                    else if (input.Contains("C"))
                    {
                        score = 1;
                        Debug.Log(score);
                        break; 
                    }
                } 
                
            }
        }
        else if (p.name == "Q4")
        {
            for (int i = 0; i < input.Count - 2; i++)
            {
                if (input[i] == "G" && input[i + 1] == "B" && input[i+2] == "E")
                {
                    score = 5;
                    Debug.Log(score);
                    break;
                }
            }
            if (score == 0)
            {
                for (int i = 0; i < input.Count - 1; i++)
                {
                    if (input[i] == "G" && input[i + 1] == "B")
                    {
                        score = 3;
                        Debug.Log(score);
                        break;
                    }
                    if (input[i] == "B" && input[i + 1] == "E")
                    {
                        score = 3;
                        Debug.Log(score);
                        break;
                    }
                }
            }
            if (score == 0)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] == "G" || input[i] == "B" || input[i] == "E")
                    {
                        score = 1;
                        Debug.Log(score);
                        break;
                    }
                }
            }
        }
        if (score == 0)
        {
            Debug.Log(score);
        }
        excel.gameObject.GetComponent<score_controller7_2>().totaladder(score);
        if (currentQ == 6)
        {
            excel.gameObject.GetComponent<score_controller7_2>().RecordCSV();
        }
    }

}
