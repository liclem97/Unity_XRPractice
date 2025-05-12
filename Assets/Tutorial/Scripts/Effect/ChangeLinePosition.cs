using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLinePosition : MonoBehaviour
{
    public int Index;

    private LineRenderer Target;

    private void Awake()
    {
        Target = GetComponent<LineRenderer>();
    }

    public void Call(Vector3 WorldPosition)
    {
        if (Target.useWorldSpace)
        {
            Target.SetPosition(Index, WorldPosition);
        }
        else
        {
            var LocalPosition = transform.InverseTransformPoint(WorldPosition);
            Target.SetPosition(Index, LocalPosition);
        }
    }
}
