using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextQ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Wait", 10f);
    }

    void Wait()
    {
        gameObject.GetComponent<NextScene>().NextS();
    }
}
