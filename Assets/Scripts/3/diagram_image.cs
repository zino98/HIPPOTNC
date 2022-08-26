using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diagram_image : MonoBehaviour
{
    private Sprite img;
    public GameObject diagram;

    void Start()
    {
        changeQ(1);
        Debug.Log("Image is placed");
    }

    public void changeQ(int nextQuestion)
    {
        img = null;
        switch (nextQuestion)
        {
            case 1:
                img = Resources.Load<Sprite>("3/Questions/Q1");
                diagram.GetComponent<Image>().sprite = img;
                break;

            case 2:
                img = Resources.Load<Sprite>("3/Questions/Q2");
                diagram.GetComponent<Image>().sprite = img;
                break;

            case 3:
                img = Resources.Load<Sprite>("3/Questions/Q3");
                diagram.GetComponent<Image>().sprite = img;
                break;

            case 4:
                img = Resources.Load<Sprite>("3/Questions/Q4");
                diagram.GetComponent<Image>().sprite = img;
                break;

            case 5:
                img = Resources.Load<Sprite>("3/Questions/Q5");
                diagram.GetComponent<Image>().sprite = img;
                break;
        }

    }
}
