using UnityEngine;
using System.IO;

public class score_controller7_2 : MonoBehaviour
{
    int currentQ;

    void Awake()
    {
        currentQ = 7;
    }

    public void totaladder(float score)
    {
        if (score_controller7_1.totalscore7 != "")
        {
            score_controller7_1.totalscore7 += ",";
            score_controller7_1.totalscore7 += score;
        }
        else
        {
            score_controller7_1.totalscore7 += score;
        }
    }

    public void RecordCSV()
    {
        string filename = Application.dataPath + "/Score.csv";
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine(currentQ + "," + score_controller7_1.totalscore7);
        tw.Close();
    }
}
