using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public float MinPitch = 0.8f;
    public float MaxPitch = 1.5f;

    private AudioSource Target;

    private void Awake()
    {
        Target = GetComponent<AudioSource>();
    }

    public void Call()
    {
        Target.pitch = Random.Range(MinPitch, MaxPitch);
        Target.Play();
    }
}
