using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class score_controller7_1 : MonoBehaviour
{
    string filename = "";

    public static string totalscore7 { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        totalscore7 = "";

        filename = Application.dataPath + "/Score.csv";

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
}
