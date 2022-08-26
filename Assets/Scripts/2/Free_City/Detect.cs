using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detect : MonoBehaviour
{

    void Start()
    {
        // Dialog = GameObject.Find("Dialog");
        // Question = GameObject.Find("Question").GetComponent<Text>();

        // Dialog.SetActive(false);
        // control = gameObject.AddComponent<MoveControl>();
    }

    private void FixedUpdate()
    {
         Detection();
    }

    private void Update()
    {
        // Debug.DrawRay(transform.position, -(transform.right) * 7, Color.red);
    }

    public void Detection()
    {
        RaycastHit raycastHit;


        if(Physics.Raycast(transform.position, transform.forward, out raycastHit))
        {
 
            
            if(raycastHit.transform.CompareTag("Button")) 
            {
                // Debug.Log("Button");
                raycastHit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
