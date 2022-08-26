using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_7 : MonoBehaviour
{

    public List<float> ans = new List<float>();
    public GameObject excel;

    float time = 0f;
    //public GameObject answerList;
    float score = 0f;
    int cnt = 0;
    float temp = 0;

    private void OnTriggerEnter(Collider other)
    {
    

        if (other.gameObject.layer == 20 && time-temp>=0.15 && time>=1.8f)
        {
            ans.Add(time);
            temp = time;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        
        if ((time > 18f) && (gameObject.name.ToString() == "Q1") && cnt==0)
        {
            score_drum1();
            cnt += 1;
            
            
        }
        else if ((time > 18f) && (gameObject.name.ToString() == "Q2") && cnt==0)
        {
            score_drum2();
            cnt += 1;
           
        }

    }

    void score_drum1()
    {
        for (int i=0; i<ans.Count -1; i++)
        {
            if (ans[i + 1] - ans[i] >= 0.95f && ans[i + 1] - ans[i] <= 1.05f) score += 1;
            else if (ans[i + 1] - ans[i] >= 0.9f && ans[i + 1] - ans[i] <= 1.1f) score += 0.92f;
            else if (ans[i + 1] - ans[i] >= 0.85f && ans[i + 1] - ans[i] <= 1.15f) score += 0.82f;
            else if (ans[i + 1] - ans[i] >= 0.77f && ans[i + 1] - ans[i] <= 1.23f) score += 0.7f;
            else if (ans[i + 1] - ans[i] >= 0.7f && ans[i + 1] - ans[i] <= 1.3f) score += 0.6f;
            else score += 0.2f;
            
        }
        score = score / (ans.Count-1) * 5;
        //Debug.Log(score);
        excel.gameObject.GetComponent<score_controller7_1>().totaladder(score);
    }

    void score_drum2()
    {

        int a = 0;
        for (int i = 0; i < ans.Count-2; i++)
        {            
            if(ans[i+1] - ans[i] >= 0.43f && ans[i+1] - ans[i] <= 0.57f && ans[i + 2] - ans[i+1] >= 0.43f && ans[i + 2] - ans[i+1] <= 0.57f)
            {
                score += 0.7f;
                a += 1;                               
            }
            else if (ans[i + 1] - ans[i] >= 0.38f && ans[i + 1] - ans[i] <= 0.62f && ans[i + 2] - ans[i + 1] >= 0.38f && ans[i + 2] - ans[i + 1] <= 0.62f)
            {
                score += 0.6f;
                a += 1;               
            }
            else if(ans[i + 1] - ans[i] >= 0.33f && ans[i + 1] - ans[i] <= 0.68f && ans[i + 2] - ans[i + 1] >= 0.33f && ans[i + 2] - ans[i + 1] <= 0.68f)
            {
                a += 1;
                score += 0.45f;
            }
            else
            {
                a += 1;
                score += 0.1f;
                continue;
            }
            

            if (i + 3 >= ans.Count)
            {
                score += 0.3f;
            }
            else if (ans[i + 3] - ans[i + 2] >= 0.9f && ans[i + 3] - ans[i + 2] <= 1.1f)
            {
                score += 0.3f;
            }
            else if(ans[i + 3] - ans[i + 2] >= 0.8f && ans[i + 3] - ans[i + 2] <= 1.2f)
            {
                score += 0.2f;
            }
            else if (ans[i + 3] - ans[i + 2] >= 0.7f && ans[i + 3] - ans[i + 2] <= 1.3f)
            {
                score += 0.1f;
            }

            i += 2;
            

            
        }
        if (ans.Count <= 2) score = 0;
        else
        {
            score = (score / a) * 5;
            score = Mathf.Round(score * 100) * 0.01f;
        }
        //Debug.Log(score);
        excel.gameObject.GetComponent<score_controller7_1>().totaladder(score);
    }


}
