using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class bin_controller : MonoBehaviour
{
    private Sprite[] rest;
    private Sprite answer;
    public GameObject[] canvas = new GameObject[4];

    public int answerBin;

    void Start()
    {
        Transform(canvas, 1);
    }

    public void Transform(GameObject[] canvas, int nextQuestion)
    {
        folderloader(nextQuestion);
        Array.Resize(ref rest, rest.Length + 1);
        rest[rest.Length - 1] = answer; // to insert the last element inside the array 
        shuffle(rest);

        // to assign the diagram to the canvas
        for (int i = 0; i < canvas.Length; ++i)
        {
            if (rest[i] == answer)
            {
                answerBin = i;
            }

            canvas[i].GetComponent<Image>().sprite = rest[i];
            Debug.Log("Image is Placed");
        }
    }

    void folderloader(int nextQuestion)
    {
        rest = Array.Empty<Sprite>();
        answer = null;

        switch (nextQuestion)
        {
            case 1:
                answer = Resources.Load<Sprite>("3/1/answer"); // answer sprite (later use for if statement)
                rest = Resources.LoadAll<Sprite>("3/1/rest");
                break;

            case 2:
                answer = Resources.Load<Sprite>("3/2/answer"); // answer sprite (later use for if statement)
                rest = Resources.LoadAll<Sprite>("3/2/rest");
                break;

            case 3:
                answer = Resources.Load<Sprite>("3/3/answer"); // answer sprite (later use for if statement)
                rest = Resources.LoadAll<Sprite>("3/3/rest");
                break;

            case 4:
                answer = Resources.Load<Sprite>("3/4/answer"); // answer sprite (later use for if statement)
                rest = Resources.LoadAll<Sprite>("3/4/rest");
                break;

            case 5:
                answer = Resources.Load<Sprite>("3/5/answer"); // answer sprite (later use for if statement)
                rest = Resources.LoadAll<Sprite>("3/5/rest");
                break;
        }

    }

    void shuffle(Sprite[] all)
    {
        for (int i = 0; i < all.Length; ++i)
        {
            Sprite temp = all[i];
            int r = UnityEngine.Random.Range(i, all.Length);
            all[i] = all[r];
            all[r] = temp;
        }
    }
}
