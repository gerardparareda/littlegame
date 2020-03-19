using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


    public Rigidbody rb;
    public float moveSpeed;
    Vector3 movement;



    void Start()
    {
        moveSpeed = 10.0f;
    }

    
    void Update()
    {
        ProcessInputs();
        //transform.Translate(-moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, - moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0);
        Move();
    }

    private void Move(){
        rb.velocity = new Vector3(moveSpeed * movement.x, moveSpeed * movement.y, moveSpeed * movement.z);
    }

    private void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxis("Vertical"), 0.0f, - Input.GetAxis("Horizontal"));

    }
}
