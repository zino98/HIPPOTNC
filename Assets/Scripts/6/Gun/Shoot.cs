using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    public LayerMask hittableMask;
    public GameObject hitEffectPrefab;
    public Transform shootPoint;

    private float shootDelay = 0.5f;
    private float maxDistance = 100f;

    public UnityEvent<Vector3> onShootSuccess;
    public UnityEvent onShootFail;

    private Magazine magazine;

    private void Awake()
    {
        magazine = GetComponent<Magazine>();
    }
    private void Start()
    {
        Stop();
    }

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        var wfs = new WaitForSeconds(shootDelay);

        while (true)
        {
            if(magazine.Use())
            {
                Shot();
            }
            else
            {
                onShootFail?.Invoke();
            }

            yield return wfs;
        }
    }

    public void Shot()
    {
        if(Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hitInfo, maxDistance, hittableMask))
        {
            Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.identity);

            var hitObject = hitInfo.transform.GetComponent<Hittable>();
            hitObject?.Hit();

            onShootSuccess?.Invoke(hitInfo.point);
        }
        else
        {
            var hitPoint = shootPoint.position + shootPoint.forward * maxDistance;
            onShootSuccess?.Invoke(hitPoint);
        }
    }
}
