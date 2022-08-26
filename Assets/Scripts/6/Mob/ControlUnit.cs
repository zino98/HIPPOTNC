using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlUnit : MonoBehaviour
{
    public UnityEvent OnHit;
    private void OnTriggerEnter(Collider other)
    {
        var mob = other.GetComponent<Mob>();
        if(mob != null)
        {
            OnHit?.Invoke();
            mob.Destroyed();
        }
    }
}
