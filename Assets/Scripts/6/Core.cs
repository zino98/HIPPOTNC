using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class Core : MonoBehaviour
{

    string filename = "";

    public int maxHp = 10;
    public int count;
    private int hp;

    public UnityEvent<string> OnHpChanged;
    public UnityEvent OnHit;
    public UnityEvent OnDestroy;
    public GameObject DataManager; // to get final score

    private static Core instance;

    public static Core Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Core>();
            return instance;
        }
    }

    private void Awake()
    {
        filename = Application.dataPath + "/Score.csv";

        instance = this;

    }

    private void OnEnable()
    {
        hp = maxHp;
        UpdateUI();
    }

    public void OnTriggerEnter(Collider other)
    {
        var mob = other.GetComponent<Mob>();
        if(mob != null)
        {
            OnHit?.Invoke();
            DecreaseHP(1);
            count++;
            mob.Destroyed();
        }
    }

    private void DecreaseHP(int amount)
    {
        if (hp <= 0)
            return;
        hp -= amount;

        if(hp <= 0)
        {
            hp = 0;
            OnDestroy?.Invoke();
            TextWriter tw = new StreamWriter(filename, true);
            tw.WriteLine("6," + DataManager.gameObject.GetComponent<DataManager>().Score);
            tw.Close();

        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        OnHpChanged?.Invoke($"HP: {hp}");
    }
}
