using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomAgentSpeedRatio : MonoBehaviour
{
    public float Min = 0.8f;
    public float Max = 1.5f;

    private NavMeshAgent Target;

    private void Awake()
    {
        Target = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        Target.speed *= Random.Range(Min, Max);
    }
}
