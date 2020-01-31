using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 50.0f;
    public float moveSpeed = 10.0f;
    [Range(0.0f, 0.99f)]
    public float slowDownRate = 0.5f;
    public float mathMoveForceAmp = 10.0f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveDir = Vector3.zero;

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

            float mathMoveForce = Mathf.Clamp(0.02f + Mathf.Pow(Mathf.Cos((0.5f - (rb.velocity.magnitude / maxSpeed) * Mathf.PI)/2), 0.5f), 0.0f, 1.0f);

            rb.AddForce(moveDir * (moveSpeed * mathMoveForce) * Time.deltaTime);
        }


    }

}
