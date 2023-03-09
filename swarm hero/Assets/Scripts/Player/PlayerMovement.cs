using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public float speed = 10.0f;
    public float jumpHeight = 2.0f;



    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveVertical + transform.right * moveHorizontal;

        movement *= speed;

        movement.y = rb.velocity.y;

        rb.velocity = movement;

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
