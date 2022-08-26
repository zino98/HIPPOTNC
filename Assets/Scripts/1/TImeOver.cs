using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TImeOver : MonoBehaviour
{
    public float setTime = 60;
    public TextMesh countdownText;
 
    
    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<TextMesh>();
        countdownText.text = setTime.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {   
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<SendScore>().Send();
            gameObject.GetComponent<NextQuestion>().NextQ();
            return;
        }

        countdownText.text = Mathf.Round(setTime).ToString();
    }
}
