using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowDestination : MonoBehaviour
{
    public Transform Destination = null;
    private NavMeshAgent ThisAgent = null;

    private void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ThisAgent.SetDestination(Destination.position);
    }
}
