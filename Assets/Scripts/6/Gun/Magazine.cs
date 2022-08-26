using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magazine : MonoBehaviour, IReloadable
{
    public int maxBullets = 20;
    public float chargingTime = 2f;

    public int currentBullets = 20;

    private int CurrentBullets
    {
        get => currentBullets;
        set
        {
            if (value < 0)
                currentBullets = 0;
            else if (value > maxBullets)
                currentBullets = maxBullets;
            else
                currentBullets = value;

            onBulletChanged?.Invoke(currentBullets);
            onChargeChanged?.Invoke((float)currentBullets / maxBullets);
        }
    }

    public UnityEvent onReloadStart;
    public UnityEvent onReloadEnd;

    public UnityEvent<int> onBulletChanged;
    public UnityEvent<float> onChargeChanged;

    private void Start()
    {
        CurrentBullets = maxBullets;
    }

    public bool Use(int amount = 1)
    {
        if (CurrentBullets >= amount)
        {
            CurrentBullets -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartReload()
    {
        if (currentBullets == maxBullets)
            return;

        StopAllCoroutines();
        StartCoroutine(ReloadProcess());
    }

    public void StopReload()
    {
        StopAllCoroutines();
    }

    private IEnumerator ReloadProcess()
    {
        onReloadStart?.Invoke();

        var beginTime = Time.time;
        var beginBullets = currentBullets;
        var enoughPercent = 1f - ((float)currentBullets / maxBullets);
        var enoughChargingTime = chargingTime * enoughPercent;

        while (true)
        {
            var t = (Time.time - beginTime) / enoughChargingTime;
            if (t >= 1f)
                break;

            CurrentBullets = (int)Mathf.Lerp(beginBullets, maxBullets, t);
            yield return null;
        }

        CurrentBullets = maxBullets;

        onReloadEnd?.Invoke();
    }
}
