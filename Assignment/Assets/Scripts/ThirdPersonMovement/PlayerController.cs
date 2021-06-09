using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;

    public float jumpForce;

    public Rigidbody rig;
    private void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Move()
    { 

        Vector3 playerInput = new Vector3
        {
            x = Input.GetAxis("Horizontal"),
            z = Input.GetAxis("Vertical")
        };

        Vector3 dir = transform.right * playerInput.x + transform.forward * playerInput.z;
        dir *= movSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;
    }

    private void Jump()
    {
        if(CanJump())
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool CanJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 0.1f))
        {
            return hit.collider != null;
        }

        return false;
    }

    
}
