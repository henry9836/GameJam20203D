﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float moveSpeed = 1000.0f;
    [Range(0.0f, 0.99f)]
    public float slowDownRate = 0.9f;
    public float jumpForce = 10000.0f;
    public LayerMask groundLayer;
    public LayerMask groundLayer1;
    public LayerMask groundLayer2;
    public LayerMask groundLayer3;
    public Transform feet;
    public float feetRadius = 1.0f;

    private Rigidbody rb;
    private bool grounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 moveDir = Vector3.zero;


        //Check for ground
        grounded = Physics.CheckSphere(feet.position, feetRadius, groundLayer);

        if (!grounded)
        {
            grounded = Physics.CheckSphere(feet.position, feetRadius, groundLayer1);
        }
        if (!grounded)
        {
            grounded = Physics.CheckSphere(feet.position, feetRadius, groundLayer2);
        }
        if (!grounded)
        {
            grounded = Physics.CheckSphere(feet.position, feetRadius, groundLayer3);
        }

        //If we are on the ground we can move
        if (grounded)
        {
            //Apply Input To Dir Vector
            moveDir += (transform.forward * Input.GetAxisRaw("Vertical"));
            moveDir += (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDir = moveDir.normalized;

            //Slow Down Fast If We Are Not Pressing Anything
            if (moveDir == Vector3.zero)
            {
                //Expect for y
                rb.velocity = new Vector3(rb.velocity.x * slowDownRate, rb.velocity.y, rb.velocity.z * slowDownRate);
            }

            else if (rb.velocity.magnitude < maxSpeed)
            {

                float mathMoveForce = Mathf.Clamp(0.02f + Mathf.Pow(Mathf.Cos((0.5f - (rb.velocity.magnitude / maxSpeed) * Mathf.PI) / 2), 0.5f), 0.0f, 1.0f);

                rb.AddForce(moveDir * (moveSpeed * mathMoveForce) * Time.deltaTime);
            }

            //If we want to jump then jump
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                if (rb.velocity.y < 1.0f)
                {
                    rb.AddForce(transform.up * jumpForce * Time.deltaTime);
                }
            }

        }
    }

}
