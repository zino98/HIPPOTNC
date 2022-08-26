using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOne : MonoBehaviour
{
    //public GameObject[] child;

    public int[] correct;


    public int getChildren(GameObject obj)
    {
        int count = 0;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            count++;
            counter(obj.transform.GetChild(i).gameObject, ref count);
        }
        return count;
    }

    private void counter(GameObject currentObj, ref int count)
    {
        for (int i = 0; i < currentObj.transform.childCount; i++)
        {
            count++;
            counter(currentObj.transform.GetChild(i).gameObject, ref count);
        }
    }

    private void Start()
    {
        int x = transform.childCount;
        correct = new int[x];
    }

}
