using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponStand : MonoBehaviour
{
    public void OnSocketed(SelectEnterEventArgs args)
    {
        var Reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
        Reloadable?.StartReload();
    }

    public void OnUnsocketed(SelectExitEventArgs args)
    {
        var Reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
        Reloadable?.StopReload();
    }
}
