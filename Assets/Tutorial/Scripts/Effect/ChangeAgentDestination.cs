using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeAgentDestination : MonoBehaviour
{
    public Vector3 Destination;

    private NavMeshAgent Target;

    private void Awake()
    {
        Target = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        Target.SetDestination(Destination);
    }
}
