using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLinePosition : MonoBehaviour
{
    public int index;

    private LineRenderer target;

    private void Awake()
    {
        target = GetComponent<LineRenderer>();
    }

    public void Call(Vector3 WorldPosition)
    {
        if(target.useWorldSpace)
        {
            target.SetPosition(index, WorldPosition);
        }
        else
        {
            var localPosition = transform.InverseTransformPoint(WorldPosition);
            target.SetPosition(index, localPosition);
        }
    }
}
