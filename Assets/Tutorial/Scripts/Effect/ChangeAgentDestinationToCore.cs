using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeAgentDestinationToCore : MonoBehaviour
{
    private NavMeshAgent Target;

    private void Awake()
    {
        Target = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        Target.SetDestination(Core.Instance.transform.position);
    }
}
