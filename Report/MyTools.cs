using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyTools : MonoBehaviour
{
    [MenuItem("My Tools/Add to Report %F1")]
    static void DEV_AppendToReport()
    {
        CSVManager.AppendToReport(new string[5]
        {
            "john",
            Random.Range(0,11).ToString(),
            Random.Range(0,11).ToString(),
            Random.Range(0,11).ToString(),
            Random.Range(0,11).ToString()
        });
        EditorApplication.Beep();
    }

    [MenuItem("My Tools/Reset Report %F12")]
    static void DEV_ResetReport()
    {
        CSVManager.CreateReport();
        EditorApplication.Beep();
    }
}
