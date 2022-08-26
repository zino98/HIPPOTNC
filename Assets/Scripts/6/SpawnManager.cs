using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] spawners;

    private void Start()
    {
        
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
        var length = spawners.Length;
        var wfs = new WaitForSeconds(1f);
        var delayPerSpawner = new WaitForSeconds(3f);

        while(true)
        {
            yield return wfs;
            var count = Random.Range(0, length);

            spawners[count].GetComponent<Spawner>().Play();
            yield return delayPerSpawner;
            spawners[count].GetComponent<Spawner>().Stop();

        }
    }
}
