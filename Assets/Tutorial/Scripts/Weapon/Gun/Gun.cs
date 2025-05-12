using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGrab;
    public UnityEvent OnRelease;

    public void Grab(SelectEnterEventArgs args)
    {
        var Interactor = args.interactorObject;
        if (Interactor is XRDirectInteractor)
        {
            OnGrab?.Invoke();
        }
    }

    public void Release(SelectExitEventArgs args)
    {
        var Interactor = args.interactorObject;
        if (Interactor is XRDirectInteractor)
        {
            OnRelease?.Invoke();
        }
    }
}
