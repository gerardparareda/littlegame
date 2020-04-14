using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public Interactable focus;      // Focused object of player


    public Rigidbody rb;            // RigidBody of player
    public float moveSpeed;         // Base movement speed
    //public float jumpForce = 2.0f;  // Jump force
    Vector3 movement;               // Horizontal and vertical axis global
    Vector3 jump;                   // Jump direction
    
    
    public Camera cam;                     // Main camera

    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask interactableMask;


    public float jumpHeight = 3f;


    bool isGrounded;         // Used to activate jump or not


    public CharacterController controller;

    PlayerAnimator animator;


    void Start()
    {
        animator = transform.GetChild(0).GetComponent<PlayerAnimator>();
    }

    
    void Update()
    {
        // Getting horizontal and vertical axis for movement
        ProcessInputs();
        Animate();



        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        // New movement code
        Vector3 move = transform.right * movement.x + transform.forward * movement.z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


                
        // Jump code
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // On mouse left click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if (Physics.Raycast(ray, out hit, 100, interactableMask))
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

    
    private void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxis("Vertical"), 0.0f, - Input.GetAxis("Horizontal"));
    }

    private void Animate()
    {
        if (movement.z > 0)
        {
            animator.setCurrentAnimation(1);
        } else if (movement.z < 0) {
            animator.setCurrentAnimation(2);
        }
        else if (velocity.y > 0)
        {
            animator.setCurrentAnimation(3);
        }
        else if (velocity.y < 0 && !isGrounded)
        {
            animator.setCurrentAnimation(4);
        
        } else
        {
            animator.setCurrentAnimation(0);

        }
    }

}
