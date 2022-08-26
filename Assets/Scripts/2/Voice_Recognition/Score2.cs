using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score2 : MonoBehaviour
{
    private int score = 0;
    private int count;
    private string Tag;

    private RaycastHit raycastHit;
    private GameObject Object;

    public LayerMask layerMask;
    public GameObject[] Dialog;
    public GameObject[] Objects;
    public float distance;

    private void Start()
    {
        Object = GameObject.Find("Player");
        raycastHit = Object.GetComponent<MoveControl>().raycastHit;
        
    }

    private void Update()
    {
        Check();
        count = Object.GetComponent<MoveControl>().count;
    }

    public void CheckScore(string[] values)
    {

            if (values[0] == "��" && Tag == "Paper6")
            {
                score += 3;
            }

            else if (values[0] == "��" && Tag == "Paper4")
            {
                score += 3;
            }

            else if (values[0] == "��" && Tag == "Paper5")
            {
                score += 4;
            }

            else if (values[0] == "����" && Tag == "Paper1")
            {
                score += 3;
            }

            else if (values[0] == "���ڷ�����" && Tag == "Paper2")
            {
                score += 3;
            }

            else if (values[0] == "�¾�" && Tag == "Paper3")
            {
                score += 4;
            }

            else
            {
                Dialog[count].SetActive(false);
                if (count <= 1)
                    Objects[count].SetActive(false);
            }
                

            
        

        Debug.Log("����: " + score);

    }

    private void Check()
    {
        if (Physics.Raycast(transform.position, -(transform.right), out raycastHit, distance, layerMask))
        {
            Tag = raycastHit.transform.tag;
        }
    }
    
}
