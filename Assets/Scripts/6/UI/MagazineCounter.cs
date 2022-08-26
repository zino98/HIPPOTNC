using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagazineCounter : MonoBehaviour
{
    public GameObject Object;
    private int count; 
    private TextMeshProUGUI textUI;

    void Start()
    {
        //count = Object.GetComponent<Magazine>().currentBullets;
        textUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        count = Object.GetComponent<Magazine>().currentBullets;
        textUI.text = ($"" + count);
    }
}
