using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public bool playStart = true;
    public float startFactor = 1f;
    public float additiveFactor = 0.1f;
    public float delayPerSpawnGroup = 2f;


    private void Start()
    {
        if (playStart)
            Play();
    }

    public void Play()
    {
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        var factor = startFactor;
        var wfs = new WaitForSeconds(delayPerSpawnGroup);

        while(true)
        {
            yield return wfs;

            SpawnProcess(factor);

            factor += additiveFactor;
        }
    }

    public void SpawnProcess(float factor)
    {
        var count = Random.Range(factor, factor * 2);

        for(int i = 0; i < count; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation, transform);
    }
}
