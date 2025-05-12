using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnToTarget : MonoBehaviour
{
    public Transform Target;

    public float Duration = 1f;
    public AnimationCurve Curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    public UnityEvent OnCompleted;

    public void Call()
    {
        if (!gameObject.activeInHierarchy) return;

        StopAllCoroutines();
        StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        if (Target == null) yield break;

        var BeginTime = Time.time;

        while (true)
        {
            var T = (Time.time - BeginTime) / Duration;
            if (T > 1f) break;

            T = Curve.Evaluate(T);

            transform.position = Vector3.Lerp(transform.position, Target.position, T);

            yield return null;
        }

        transform.position = Target.position;

        OnCompleted?.Invoke();
    }
}
