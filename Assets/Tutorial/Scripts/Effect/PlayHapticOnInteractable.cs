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
        // Ÿ���� ���ų�, Ÿ���� ����Ʈ �ϰ� �ִ� ���� ���ų�, Ÿ���� ����Ʈ �ϰ� �ִ� ������Ʈ�� XRBaseControllerInteractor�� �ƴϸ� ����
        if (Target == null || Target.firstInteractorSelecting == null || !(Target.firstInteractorSelecting is XRBaseControllerInteractor)) return;

        // Target.firstInteractorSelecting�� ������Ʈ�� XRBaseControllerInteractor Ÿ������ ����ȯ
        var Interactor = Target.firstInteractorSelecting as XRBaseControllerInteractor;
        if (Interactor.xrController == null) return;

        Interactor.xrController.SendHapticImpulse(Amplitude, Duration);
    }
}
