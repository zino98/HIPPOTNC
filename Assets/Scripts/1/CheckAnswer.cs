using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class CheckAnswer : MonoBehaviour
{
    public GameObject[] answer;
    XRSocketInteractor socket;
    
    public int key = 0;
    public GameObject my;
    public int index;
    public GameObject parent;

    private void Start()
    {
        //my = GetComponent<GameObject>();
        socket = GetComponent<XRSocketInteractor>();
    }

    public void SelectEnter()
    {
        IXRSelectInteractable grab = socket.GetOldestInteractableSelected();
        
        for(int i = 0; i < answer.Length; i++)
        {
            if (answer[i].name == grab.transform.name)
            {
                key = 1;
                parent.GetComponent<ScoreOne>().correct[index] = key;
                break;
            }
        }

        
    }
    public void SelectExit()
    {
        key = 0;
        parent.GetComponent<ScoreOne>().correct[index] = key;
    }

}
