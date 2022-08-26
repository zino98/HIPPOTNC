using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponStand : MonoBehaviour
{
    public void onSocketed(SelectEnterEventArgs args)
    {
        var reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
        reloadable?.StartReload();
    }

    public void onUnSocketed(SelectExitEventArgs args)
    {
        var reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
        reloadable?.StopReload();
    }
}
