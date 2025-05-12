using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayHapticOnInteractable : MonoBehaviour
{
    public float Amplitude = 0.5f;
    public float Duration = 0.05f;

    private XRBaseInteractable Target;

    private void Awake()
    {
        Target = GetComponent<XRBaseInteractable>();
    }

    public void Call()
    {
        // 타겟이 없거나, 타겟을 셀렉트 하고 있는 것이 없거나, 타겟을 셀렉트 하고 있는 오브젝트가 XRBaseControllerInteractor가 아니면 리턴
        if (Target == null || Target.firstInteractorSelecting == null || !(Target.firstInteractorSelecting is XRBaseControllerInteractor)) return;

        // Target.firstInteractorSelecting된 오브젝트를 XRBaseControllerInteractor 타입으로 형변환
        var Interactor = Target.firstInteractorSelecting as XRBaseControllerInteractor;
        if (Interactor.xrController == null) return;

        Interactor.xrController.SendHapticImpulse(Amplitude, Duration);
    }
}
