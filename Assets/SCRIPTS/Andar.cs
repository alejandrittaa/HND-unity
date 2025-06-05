using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Andar : MonoBehaviour
{
    public Transform targetPoint; // Punto al que quieres ir

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPoint.position);
    }
}
