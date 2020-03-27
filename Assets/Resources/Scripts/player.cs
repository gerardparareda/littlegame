using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


    public Rigidbody rb;
    public float moveSpeed;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Vector3 movement;
    Vector3 jump;



    void Start()
    {
        moveSpeed = 5.0f;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        jumpForce = 30.0f;
        isGrounded = false;

    }

    
    void Update()
    {
        ProcessInputs();
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        
    }

    private void Move(){
        Vector3 vel = rb.velocity;
        vel.x = moveSpeed * movement.x;
        vel.z = moveSpeed * movement.z;
        rb.velocity = vel;
    }
    
    private void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxis("Vertical"), 0.0f, - Input.GetAxis("Horizontal"));
    }


    private void OnCollisionStay()
    {
        isGrounded = true;
    }
}
