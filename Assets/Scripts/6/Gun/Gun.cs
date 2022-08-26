using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public UnityEvent onGrab;
    public UnityEvent onRelease;

    public void Grab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;
        if(interactor is XRDirectInteractor)
        {
            onGrab?.Invoke();
        }
    }

    public void Release(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject;
        if(interactor is XRDirectInteractor)
        {
            onRelease?.Invoke();
        }
    }
}
