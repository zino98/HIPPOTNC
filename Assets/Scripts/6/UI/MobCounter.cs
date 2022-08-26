using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MobCounter : MonoBehaviour
{
    public int killCount;
    public int spawnCount;

    private TextMeshProUGUI textUI;

    private void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateUI()
    {
        if (!enabled)
            return;

        textUI.text = $"Kill/Alive/Spawn\n{killCount}/{spawnCount - killCount}/{spawnCount}";
    }

    private void OnEnable()
    {
        killCount = spawnCount = 0;
        UpdateUI();
        
    }

    public void OnSpawn()
    {
        spawnCount++;
        UpdateUI();
    }

    public void Onkill()
    {
        killCount++;
        UpdateUI();
    }

    
}
