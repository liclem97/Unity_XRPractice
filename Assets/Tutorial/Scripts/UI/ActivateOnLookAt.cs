using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnLookAt : MonoBehaviour
{
    public new Camera camera;
    public Behaviour Target;

    public float ThresholdAngle = 30f;
    public float ThresholdDuration = 2f;

    private bool IsLooking = false;
    private float ShowingTime;

    private void Awake()
    {
        Target.enabled = false;
    }

    private void Update()
    {
        var Dir = Target.transform.position - camera.transform.position;
        var Angle = Vector3.Angle(camera.transform.forward, Dir); 

        if (Angle <= ThresholdAngle)
        {
            if (!IsLooking)
            {
                IsLooking = true;
                ShowingTime = Time.time + ThresholdDuration;
            }
            else
            {
                if (!Target.enabled && Time.time > ShowingTime)
                {
                    Target.enabled = true;
                }
            }

        }
        else
        {
            if (IsLooking)
            {
                IsLooking = false;
                Target.enabled = false;
            }
        }
    }
}
