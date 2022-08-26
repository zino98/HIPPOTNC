using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private float duration = 0.05f;

    private Light target;

    private void Awake()
    {
        target = GetComponent<Light>();
    }

    public void Call()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        target.enabled = true;

        yield return duration;

        target.enabled = false;
    }
}
