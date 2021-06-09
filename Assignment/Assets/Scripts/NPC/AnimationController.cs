using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public float RunVelocity = 0.1f;
    public string AnimationRunParamName = "Run";

    private NavMeshAgent ThisNavMeshAgent = null;
    private Animator ThisAnimator = null;
    private float MaxSpeed;

    private void Awake()
    {
        ThisNavMeshAgent = GetComponent<NavMeshAgent>();
        ThisAnimator = GetComponent<Animator>();
        MaxSpeed = ThisNavMeshAgent.speed;
    }

    private void Update()
    {
        ThisAnimator.SetBool(AnimationRunParamName, ThisNavMeshAgent.velocity.magnitude > RunVelocity);
    }
}
