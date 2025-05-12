using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLineRenderer : MonoBehaviour
{
    public float Duration = 0.05f;

    private LineRenderer Target;

    private void Awake()
    {
        Target = GetComponent<LineRenderer>();
    }

    public void Call()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        Target.enabled = true;

        yield return new WaitForSeconds(Duration);

        Target.enabled = false;
    }
}
