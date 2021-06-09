using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SightLine : MonoBehaviour
{
    public Transform EyePoint;
    public string TargetTag = "Player";
    public float FieldOfView = 70f;

    public bool IsTargetInSightLine { get; set; } = false;
    public Vector3 LastKnownSighting { get; set; } = Vector3.zero;

    private SphereCollider ThisCollider;

    private void Awake()
    {
        ThisCollider = GetComponent<SphereCollider>();
        LastKnownSighting = transform.position;

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(TargetTag))
        {
            UpdateSight(other.transform);
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag(TargetTag)) { IsTargetInSightLine = false; }
    }

    private bool HasClearLineOfSightToTarget(Transform target)
    {
        RaycastHit Info;

        Vector3 DirToTarget = (target.position - EyePoint.position).normalized;
        if(Physics.Raycast(EyePoint.position, DirToTarget, out Info, ThisCollider.radius))
        {
            if(Info.transform.CompareTag(TargetTag))
            {
                return true;
            }
        }

        return false;
    }

    private bool TargetInFOV(Transform target)
    {
        Vector3 DirToTarget = target.position - EyePoint.position;
        float Angle = Vector3.Angle(EyePoint.position, DirToTarget);

        if(Angle <= FieldOfView)
        {
            return true;
        }

        return false;
    }

    private void UpdateSight(Transform target)
    {
        IsTargetInSightLine = HasClearLineOfSightToTarget(target) && TargetInFOV(target);

        if(IsTargetInSightLine)
        {
            LastKnownSighting = target.position;
        }
    }
}
