using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTime : MonoBehaviour
{
    private float startTime;
    public float sur;

    public TextMeshProUGUI textUI;

    private void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();

    }

    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        sur = Time.time - startTime;
        textUI.text = $"Survival Time\n{sur:0.0}s";
    }
}
