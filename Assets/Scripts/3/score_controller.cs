using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class score_controller : MonoBehaviour
{
    string filename = "";

    // Start is called before the first frame update
    void Awake()
    {
        filename = Application.dataPath + "/Score.csv";
    }


    public void TotalScore(string total)
    {
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("3," + total);
        tw.Close();
    }
}
