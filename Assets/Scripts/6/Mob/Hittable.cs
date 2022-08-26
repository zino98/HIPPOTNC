using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public UnityEvent onHit;

    public void Hit()
    {
        onHit?.Invoke();
    }
}
