using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionIntensity : MonoBehaviour
{
    public float Min = 0f;
    public float Max = 3f;

    private Renderer Target;

    private void Awake()
    {
        Target = GetComponent<Renderer>();
    }

    public void Call(float Ratio)
    {
        var Intensity = Mathf.Lerp(Min, Max, Ratio);
        Target.material.SetColor("_EmissionColor", Target.material.color * Intensity);

    }
}