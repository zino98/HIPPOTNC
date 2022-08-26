using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class score_controller1 : MonoBehaviour
{
    string filename = "";

    public string totalscore;
    public bool is_totalrecorded;

    void Awake()
    {
        filename = Application.dataPath + "/Score.csv";
    }

    public void totaladder(float score)
    {
        if (totalscore != "")
        {
            totalscore += ",";
            totalscore += score;
        }
        else
        {
            totalscore += score;
        }
        if (is_totalrecorded == true)
        {
            TotalScore();
        }
        is_totalrecorded = true;
    }

    public void TotalScore()
    {
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("1," + totalscore);
        tw.Close();
    }

}
