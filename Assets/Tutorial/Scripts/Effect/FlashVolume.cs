using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FlashVolume : MonoBehaviour
{
    public float Duration = 0.05f;

    private Volume Target;

    private void Awake()
    {
        Target = GetComponent<Volume>();
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
