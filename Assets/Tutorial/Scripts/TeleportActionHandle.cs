using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportActionHandle : MonoBehaviour
{
    public InputActionReference InputActionRef;

    public UnityEvent OnShow;
    public UnityEvent OnHide;

    private void OnEnable() // gameObject.SetActive(true)�� ����
    {
        InputActionRef.action.performed += OnPerformed; // �ݹ� �̺�Ʈ ���
        InputActionRef.action.canceled += OnCanceled;
    }

    private void OnDisable() // gameObject.SetActive(false)�� ����
    {
        InputActionRef.action.performed -= OnPerformed; // �ݹ� �̺�Ʈ ����
        InputActionRef.action.canceled -= OnCanceled;
    }

    public void OnPerformed(InputAction.CallbackContext Obj)
    {
        StartCoroutine(DelayCall(OnShow));
    }

    public void OnCanceled(InputAction.CallbackContext Obj)
    {
        StartCoroutine(DelayCall(OnHide));
    }

    private IEnumerator DelayCall(UnityEvent e)
    {
        yield return null; // yield return null�� ���� �� ������ ���� �� UnityEvent�� ȣ��
        e?.Invoke();
    }
}
