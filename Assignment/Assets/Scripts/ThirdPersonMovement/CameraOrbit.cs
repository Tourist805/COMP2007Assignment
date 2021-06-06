using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float LookSensitivity;
    public float minXLook;
    public float maxXLook;
    public Transform camAnchor;

    public bool invertXRotation;

    private float curXRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * x * LookSensitivity;

        if (invertXRotation)
            curXRot += y * LookSensitivity;
        else
            curXRot -= y * LookSensitivity;

        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);

        Vector3 clampedAngle = camAnchor.eulerAngles;
        clampedAngle.x = curXRot;

        camAnchor.eulerAngles = clampedAngle;
    }
}
