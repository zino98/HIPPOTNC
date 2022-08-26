using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_7_2 : MonoBehaviour
{
    Transform p;


    private void Start()
    {
        p = gameObject.transform.parent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 20)
        {
            p.GetComponent<SendScore_7_2>().input.Add(gameObject.name);
        }
    }

}
