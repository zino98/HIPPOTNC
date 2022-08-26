using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAndExit : MonoBehaviour
{
    public void OnSeletExit()
    {
        
        transform.position = new Vector3(10, transform.position.y, transform.position.z);
    }
}
