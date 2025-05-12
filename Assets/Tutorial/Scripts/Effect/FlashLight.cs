using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public float Duration = 0.05f;

    private Light Target;

    private void Awake()
    {
        Target = GetComponent<Light>();
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
