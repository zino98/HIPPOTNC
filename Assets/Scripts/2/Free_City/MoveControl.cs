using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControl : MonoBehaviour
{
    public float moveSpeed;
    public float distance;
    public LayerMask layerMask;
    public RaycastHit raycastHit;

    public GameObject[] Dialog;
    public GameObject[] Objects;
    public InputActionAsset inputActions;
    public Transform tr;

    private AudioSource audioSource;
    private float length;
    private Transform[] points;

    private int nextIndex = 1;
    public int count = -1;

    public bool isMove = true;
    public bool isCheck = true;
    private bool playOnStart = false;

    void Start()
    {
        GameObject wayPointGroup = GameObject.Find("WayPoint");

        tr = GetComponent<Transform>();
        points = wayPointGroup.GetComponentsInChildren<Transform>();
        audioSource = GetComponent<AudioSource>();
        length = audioSource.clip.length;
        inputActions.Disable();

        if (playOnStart)
            Play();
    }


    void Update()
    {
        AutoMove();

    }

    private void FixedUpdate()
    {
        Detection();

    }

    private void Play()
    {
        isMove = false;
        audioSource.Play();

        Invoke("Go", length);
    }

    private void Go()
    {
        isMove = true;
        isCheck = true;
    }

    private void Detection()
    {
        //RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(transform.position, -(transform.right), out raycastHit, distance, layerMask))
        {
            string tag = raycastHit.transform.tag;

            switch (tag)
            {
                case "Paper1":
                    Dialog[0].SetActive(true);
                    Objects[0].SetActive(true);
                    inputActions.Enable();
                    raycastHit.transform.gameObject.SetActive(false);

                    isMove = false;
                    isCheck = false;

                    count++;
                    break;

                case "Paper2":
                    Dialog[1].SetActive(true);
                    Objects[1].SetActive(true);
                    inputActions.Enable();
                    raycastHit.transform.gameObject.SetActive(false);

                    isMove = false;
                    isCheck = false;

                    count++;
                    break;

                case "Paper3":
                    Dialog[2].SetActive(true);
                    //Objects[2].SetActive(true);
                    inputActions.Enable();
                    raycastHit.transform.gameObject.SetActive(false);

                    isMove = false;
                    isCheck = false;

                    count++;
                    break;

                case "Paper4":
                    Dialog[3].SetActive(true);
                    
                    inputActions.Enable();
                    raycastHit.transform.gameObject.SetActive(false);

                    isMove = false;
                    isCheck = false;

                    count++;
                    break;

                case "Paper5":
                    Dialog[4].SetActive(true);
                    
                    inputActions.Enable();
                    raycastHit.transform.gameObject.SetActive(false);

                    isMove = false;
                    isCheck = false;

                    count++;
                    break;

                case "Paper6":
                    Dialog[5].SetActive(true);
                    
                    inputActions.Enable();
                    raycastHit.transform.gameObject.SetActive(false);

                    isMove = false;
                    isCheck = false;

                    count++;
                    break;
            }

        }


    }

    private void AutoMove()
    {
        if (isMove && isCheck)
        {
            Vector3 Direction = points[nextIndex].position - tr.position;
            Direction = Direction.normalized;

            //Quaternion rot = Quaternion.LookRotation(Direction);

            //tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * moveSpeed);
            tr.Translate(Direction * moveSpeed * Time.deltaTime);
        }


    }

    public void Solve(string[] values)
    {
        
            if (values[0] == "문")
            {
                isMove = true;
                isCheck = true;
                Dialog[5].SetActive(false);
            }

            else if (values[0] == "인")
            {
                isMove = true;
                isCheck = true;
                Dialog[3].SetActive(false);
            }


            else if (values[0] == "성")
            {
                isMove = true;
                isCheck = true;
                Dialog[4].SetActive(false);
            }

            else if (values[0] == "소파")
            {
                isMove = true;
                isCheck = true;
                Dialog[0].SetActive(false);
                Objects[0].SetActive(false);
            }

            else if (values[0] == "전자레인지")
            {
                isMove = true;
                isCheck = true;
                Dialog[1].SetActive(false);
                Objects[1].SetActive(false);
            }

            else if (values[0] == "태양")
            {
                isMove = true;
                isCheck = true;
                Dialog[2].SetActive(false);
            }
        
    }
   
    public void Pass(string[] names)
    {
        if (names[0] == "Trash")
        {
            Debug.Log("It is Wrong");
            isMove = true;
            isCheck = true;
            Dialog[count].SetActive(false);
            if (count <= 1)
                Objects[count].SetActive(false);

        }
    }


    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Point")
        {
            nextIndex++;

            if (nextIndex > points.Length - 1)
            {
                isMove = false;
                nextIndex = 10;

            }

        }  
    }

}
