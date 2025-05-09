using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomColor : MonoBehaviour
{
    public float HueMin = 0f;
    public float HueMax = 1f;
    public float SaterationMin = 0.7f;
    public float SaterationMax = 1f;
    public float ValueMin = 0.7f;
    public float ValueMax = 1f;

    public UnityEvent<Color> OnCreated;

    public void Call()
    {
        var Color = Random.ColorHSV(HueMin, HueMax, SaterationMin, SaterationMax, ValueMin, ValueMax);
        OnCreated.Invoke(Color);
    }
}

