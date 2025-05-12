using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Bomb : MonoBehaviour
{
    public enum State
    {
        Idle,
        Drop,
    }

    public float ExplosionRadius;
    public LayerMask ExplosionHittableMask;

    public float RecycleDelay = 1f;

    public UnityEvent OnExplosion;
    public UnityEvent OnRecycle;

    private State state;

    public void Drop()
    {
        state = State.Drop;
    }

    public void Throw()
    {
        var Interactable = GetComponent<XRGrabInteractable>();
        Interactable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)Interactable); // XR Interaction Manager에게 Selection을 취소한다고 알림

        var RB = GetComponent<Rigidbody>();
        RB.AddRelativeForce(new Vector3(0f, 150f, 300f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state == State.Idle) return;

        Explosion();
    }

    private void Explosion()
    {   
        // 구체 형태로 반경 내의 콜라이더를 수집함
        var Overlaps = Physics.OverlapSphere(transform.position, ExplosionRadius, ExplosionHittableMask, QueryTriggerInteraction.Collide);

        foreach (var Overlap in Overlaps)
        {
            var HitObject = Overlap.GetComponent<Hittable>();
            HitObject?.Hit();
        }

        OnExplosion?.Invoke();
        Invoke(nameof(Recycle), RecycleDelay);
    }

    private void Recycle()
    {
        state = State.Idle;
        OnRecycle?.Invoke();
    }
}
