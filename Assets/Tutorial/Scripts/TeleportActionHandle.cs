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

    private void OnEnable() // gameObject.SetActive(true)시 실행
    {
        InputActionRef.action.performed += OnPerformed; // 콜백 이벤트 등록
        InputActionRef.action.canceled += OnCanceled;
    }

    private void OnDisable() // gameObject.SetActive(false)시 실행
    {
        InputActionRef.action.performed -= OnPerformed; // 콜백 이벤트 해제
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
        yield return null; // yield return null을 통해 한 프레임 지연 후 UnityEvent를 호출
        e?.Invoke();
    }
}
