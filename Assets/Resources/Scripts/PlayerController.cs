using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public Interactable focus;      // Focused object of player


    public Rigidbody rb;            // RigidBody of player
    public float moveSpeed;         // Base movement speed
    public float jumpForce = 2.0f;  // Jump force
    public bool isGrounded;         // Used to activate jump or not
    Vector3 movement;               // Horizontal and vertical axis global
    Vector3 jump;                   // Jump direction
    
    
    Camera cam;                     // Main camera



    void Start()
    {
        moveSpeed = 5.0f;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        jumpForce = 30.0f;
        isGrounded = false;
        cam = Camera.main;
    }

    
    void Update()
    {
        // Getting horizontal and vertical axis for movement
        ProcessInputs();
        // Move player with velocity
        Move();


        // Jump code
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // On mouse left click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    float distance = Vector3.Distance(transform.position, interactable.transform.position);
                    
                    if(distance < interactable.radius)
                    {
                        interactable.Hit();
                    }

                }
            }

        }

        // On mouse right click
        if (Input.GetMouseButtonDown(1))
        {
            // Create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if(Physics.Raycast(ray, out hit, 100))
            {
                // Get the interactable object
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if(interactable != null)
                {
                    float distance = Vector3.Distance(transform.position, interactable.transform.position);
                    if (distance < interactable.radius)
                    {
                        // Interact with object
                        interactable.Interact();
                    } 
                }
            }
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
