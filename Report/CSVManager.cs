using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVManager : MonoBehaviour
{
    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[5]
    {
        "character_name",
        "hp",
        "mp",
        "damage",
        "armor"
    };

    private static string timeStampHeader = "tiem_stamp";

    public static void AppendToReport(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();

        using (StreamWriter sw = File.AppendText(GetFilePath())) {
            string finalstring = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalstring != "")
                {
                    finalstring += reportSeparator;
                }
                finalstring += strings[i];
            }
            finalstring += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalstring);
        }
    }

    public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            for(int i = 0; i < reportHeaders.Length; i++)
            {
                if(finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();
        if(!File.Exists(file))
        {
            CreateReport();
        }
    }

    static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }

    static string GetTimeStamp()
    {
        return System.DateTime.Now.ToString();
    }
}
