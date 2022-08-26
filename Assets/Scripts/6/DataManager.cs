using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private GameObject Object;
    private GameObject Object2;
    private GameObject Object3;

    private float allCount;
    private float killCount;
    private float byCore;
    private float spawnCount;
    private float Rate;
    private float F_time;
    public int Score;

    private bool On;
    private string Time;
    private void Start()
    {
        Object = GameObject.Find("Panel_Mob Counter");
        Object2 = GameObject.Find("Core");
        Object3 = GameObject.Find("Panel_Survival Time");

    }

    // Update is called once per frame
    private void Update()
    {
        allCount = Object.GetComponentInChildren<MobCounter>().killCount;
        byCore = Object2.GetComponent<Core>().count;
        killCount = allCount - byCore;
        Check_Count();
        Check_Time();
     
    }

    public void Print()
    {
        Debug.Log("비율: " + Rate);
        Debug.Log("점수: " + Score);
        Debug.Log("시간: " + F_time);
    }

    private void Check_Count()
    {
        spawnCount = Object.GetComponentInChildren<MobCounter>().spawnCount;

        if (spawnCount == 0)
            return;

        if (spawnCount > 0)
            Rate = (killCount / spawnCount) * 100;

        if (80 < Rate && Rate <= 90)
            Score = 10;
        else if (70 < Rate && Rate <= 80)
            Score = 9;
        else if (60 < Rate && Rate <= 70)
            Score = 8;
        else if (50 < Rate && Rate <= 60)
            Score = 7;
        else
            Score = 6;
    }

    private void Check_Time()
    {
        On = Object3.GetComponentInChildren<SurvivalTime>().enabled;
        F_time = Object3.GetComponentInChildren<SurvivalTime>().sur;

        if (F_time == 0)
            return;

        if (On)
        {
            Time = string.Format("{0:0.##}", Object3.GetComponentInChildren<SurvivalTime>().sur);
        }


        if (60 < F_time)
            Score += 10;
        else if (50 < F_time && F_time <= 60)
            Score += 9;
        else if (40 < F_time && F_time <= 50)
            Score += 8;
        else if (30 < F_time && F_time <= 40)
            Score += 7;
        else
            Score += 6;
    }


}
