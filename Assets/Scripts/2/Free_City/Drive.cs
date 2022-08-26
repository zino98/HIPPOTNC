using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    private Rigidbody Rigidbody;

    public float speed;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Go();
    }

    private void Go()
    {
        Rigidbody.AddForce(transform.forward * speed);
    }

    
}
