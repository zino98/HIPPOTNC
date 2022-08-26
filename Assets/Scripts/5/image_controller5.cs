using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class image_controller5 : MonoBehaviour
{
    public GameObject itself;
    public GameObject diagram;
    public Sprite[] rest;
    public Sprite answer;

    public void changer()
    {
        if (itself.gameObject.layer == LayerMask.NameToLayer("11"))
        {
            Debug.Log("11");
            diagram.GetComponent<Image>().sprite = rest[0];
        }
        else if (itself.gameObject.layer == LayerMask.NameToLayer("22"))
        {
            Debug.Log("22");
            diagram.GetComponent<Image>().sprite = rest[1];
        }
        else if (itself.gameObject.layer == LayerMask.NameToLayer("33"))
        {
            Debug.Log("33");
            diagram.GetComponent<Image>().sprite = rest[2];
        }
        else
        {
            Debug.Log("answer");
            diagram.GetComponent<Image>().sprite = answer;
        }
    }
}
