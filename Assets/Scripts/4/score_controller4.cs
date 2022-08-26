using UnityEngine;
using System.IO;

public class score_controller4 : MonoBehaviour
{
    string filename = "";

    public string totalscore;

    void Awake()
    {
        filename = Application.dataPath + "/Score.csv";
        totalscore = "";
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
    }

    public void TotalScore()
    {
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("5," + totalscore);
        tw.Close();
    }
}
