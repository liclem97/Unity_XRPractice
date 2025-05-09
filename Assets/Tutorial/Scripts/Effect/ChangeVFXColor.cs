using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVFXColor : MonoBehaviour
{
    public float ArrangeRange = 0.5f;

    private ParticleSystem Target;

    private void Awake()
    {
        Target = GetComponent<ParticleSystem>();
    }

    public void Call(Color color)
    {
        var Main = Target.main;
        Main.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1f - ArrangeRange, 1f + ArrangeRange));
    }
}
