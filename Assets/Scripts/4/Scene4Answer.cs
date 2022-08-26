using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Answer : MonoBehaviour
{
    public List<GameObject> come_food;
    public int my_layer;
    public List<GameObject> answer;
    public GameObject excel;
    public int currentQ;
    public bool is_lastQ;

    float score;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == my_layer)
        {
            come_food.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == my_layer)
        {
            come_food.Remove(other.gameObject);
        }
    }


    public void calculate_score()
    {
        int small;
        if (answer.Count <= come_food.Count) small = answer.Count;
        else
        {
            small = come_food.Count;
        } 
         

        for(int i = 0; i<small; i++)
        {
            if (come_food[i].transform.name == answer[i].transform.name) score += 1;
        }

        score = score * 20 / 14f;
        score = Mathf.Round(score * 100) * 0.01f;
        Debug.Log(score);
        excel.gameObject.GetComponent<score_controller4>().totaladder(score);
        if (is_lastQ == true)
        {
            excel.gameObject.GetComponent<score_controller4>().TotalScore();
        }
    }
}
