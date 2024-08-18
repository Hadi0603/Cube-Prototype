using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public float speed = 6f;
    public float jumpForce = 5f;
    public float turnSmoothTime = 0.1f;
    public Vector3 cameraOffset = new Vector3(0, 5, -7);

    private Rigidbody rb;
    private float turnSmoothVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;
        if (Input.GetKey(KeyCode.W)) vertical = 1f;
        if (Input.GetKey(KeyCode.S)) vertical = -1f;
        if (Input.GetKey(KeyCode.A)) horizontal = -1f;
        if (Input.GetKey(KeyCode.D)) horizontal = 1f;
        if (Input.GetKey(KeyCode.Q))
        {
            if (transform.localScale.x < 3f)
            {
                transform.localScale += new Vector3(0.05f, 0, 0);
            }
        }
        if(Input.GetKey(KeyCode.Z))
        {
            if(transform.localScale.x > 0.5f)
            {
                transform.localScale -= new Vector3(0.05f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (transform.localScale.z < 3f)
            {
                transform.localScale += new Vector3(0, 0, 0.05f);
            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            if (transform.localScale.z > 0.5f)
            {
                transform.localScale -= new Vector3(0, 0, 0.05f);
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            if (transform.localScale.y < 3f)
            {
                transform.localScale += new Vector3(0, 0.05f, 0);
            }
        }
        if (Input.GetKey(KeyCode.C))
        {
            if (transform.localScale.y > 1f)
            {
                transform.localScale -= new Vector3(0, 0.05f, 0);
            }
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(rb.position + moveDir.normalized * speed * Time.deltaTime);
        }
    }

    
}
