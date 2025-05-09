using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionColor : MonoBehaviour
{
    public float Intensity = 5f;

    private Renderer Target;

    private void Awake()
    {
        Target = GetComponent<Renderer>();
    }

    public void Call(Color color)
    {
        Target.material.SetColor("_EmissionColor", color * Intensity);
    }

}
