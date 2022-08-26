using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython;
using System;


public class DataManager : MonoBehaviour
{

    private void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Run();
        }
    }

    private void Run()
    {
        var engine = IronPython.Hosting.Python.CreateEngine();
        var paths = engine.GetSearchPaths();
        var scope = engine.CreateScope();

        paths.Add(@"C:\Users\USER\AppData\Local\Programs\Python\Python39\Lib\site-packages");
        paths.Add(@"C:\Users\USER\AppData\Local\Programs\Python\Python39\Lib");

        engine.SetSearchPaths(paths);

        var source = engine.CreateScriptSourceFromFile("C:/Users/User/Desktop/Test/Assets/Report/Pdf_Convert.py");

        source.Execute(scope);

        Debug.Log("Complete");
    }
}
