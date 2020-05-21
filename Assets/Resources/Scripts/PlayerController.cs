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
    public Item usingItem;


    public float jumpHeight = 3f;


    bool isGrounded;         // Used to activate jump or not


    public CharacterController controller;

    PlayerAnimator animator;
    Transform textureContainer;

    public bool playerEnabled;

    //public Animator playerAnimator; // Reference to the unity animator
    private bool facingLeft = false;
    public PlayerAnimationController playerAnimController; //Reference to the controller of the animations

    GameObject hoveredGameObject;

    Ray ray;
    RaycastHit hit;


    void Start()
    {

        animator = transform.GetChild(0).GetComponent<PlayerAnimator>();
        textureContainer = transform.GetChild(0);
    }

    
    void Update()
    {
        // Getting horizontal and vertical axis for movement
        ProcessInputs();
        Animate();
            
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask | interactableMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
/*<<<<<<< HEAD

        // Movement code
        Vector3 move = transform.right * movement.x + transform.forward * movement.z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Jump code
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
=======*/

        // Movement code
        Vector3 move = transform.right * movement.x + transform.forward * movement.z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

                
        // Jump code
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        ray = cam.ScreenPointToRay(Input.mousePosition);


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

                    if (distance < interactable.radius)
                    {
                        interactable.Hit();
                    }
                }
            }
        }

        // On mouse right click
        if (Input.GetMouseButtonDown(1))
        {


            // If the ray hits
            if (Physics.Raycast(ray, out hit, 100, interactableMask))
            {

                // Get the interactable object
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
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

        if (Physics.Raycast(ray, out hit, 100, interactableMask))
        {
            if (hit.collider.gameObject.GetComponent<Outline>() != null && hoveredGameObject != hit.collider.gameObject)
            {
                if (hoveredGameObject != null)
                {
                    hoveredGameObject.GetComponent<Outline>().Deselect();
                    hoveredGameObject = null;
                }
                hoveredGameObject = hit.collider.gameObject;
                hoveredGameObject.GetComponent<Outline>().Select();
            }
        }
        else
        {
            if (hoveredGameObject != null)
            {
                hoveredGameObject.GetComponent<Outline>().Deselect();
                hoveredGameObject = null;
            }
        }
    }

    public void setUsingItem(Item item)
    {
        this.usingItem = item;
    }
    private void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxis("Vertical"), 0.0f, - Input.GetAxis("Horizontal"));
    }

    /*private void Animate()
    {

        // If movement is to the left flip texture container to the left
        if (movement.z > 0 && textureContainer.localScale.x > 0)
        {
            textureContainer.localScale = new Vector3(textureContainer.localScale.x * -1.0f, textureContainer.localScale.y, textureContainer.localScale.z);
        }
        else if (movement.z < 0 && textureContainer.localScale.x < 0)
        {
            textureContainer.localScale = new Vector3(textureContainer.localScale.x * -1.0f, textureContainer.localScale.y, textureContainer.localScale.z);
        }
        // If movement is left or right
        if ((movement.z > 0.3f || movement.x > 0.3f || movement.z < -0.3f || movement.x < -0.3f) && isGrounded)
        {
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
    }*/

    private void Animate()
    {

        //facingLeft = movement.z != 0 ? movement.z > 0 : facingLeft; // Only if moving update facingLeft

        // Update velocity param for animator
        /*playerAnimator.SetBool("facingLeft", facingLeft);
        playerAnimator.SetBool("isGrounded", true);
        playerAnimator.SetBool("isMoving", movement.z != 0);*/

        /*Debug.Log("horizontalVelocity " + movement.z + " ");
        Debug.Log("facingLeft " + facingLeft + " ");
        Debug.Log("isGrounded " + isGrounded + " ");
        Debug.Log("isStopped " + movement.z == 0 + " ");*/

        /*if (velocity.z != 0)
        {
            if (animState != 2)
            {
                playerAnimator.SetTrigger("movingLeft");
                animState = 2;
            }
            if (animState != 3)
            {
                playerAnimator.SetTrigger("movingLeft");
                animState = 3;
            }
        }

        if (velocity.x != 0)
        {

        }

        if (isGrounded && facingLeft)
        {
            playerAnimator.SetTrigger("idleLeft");
            animState = 0;
        }
        if (isGrounded && !facingLeft)
        {
            playerAnimator.SetTrigger("idleRight");
            animState = 1;
        }*/

        /*isGrounded = true;
        //Debug.Log("Velocity: " + movement);
        if (isGrounded) {
            if (movement.z != 0 | movement.x != 0)
            {
                playerAnimController.SetFacingLeft(movement.z != 0 ? movement.z > 0 : playerAnimController.isFacingLeft());
                playerAnimController.WalkAnimation();
                //Debug.Log("Moving");
            } else
            {
                playerAnimController.IdleAnimation();
                //Debug.Log("Idle");
            }
        }
        if (!isGrounded) playerAnimController.JumpAnimation();*/

        isGrounded = true;
        //Debug.Log("Velocity: " + movement);
        if (movement.z > 0) playerAnimController.SetFacingLeft(true);
        if (movement.z < 0) playerAnimController.SetFacingLeft(false);
        if (isGrounded)
        {
            if (movement.z != 0 | movement.x != 0)
            {
                playerAnimController.SetFacingLeft(velocity.z != 0 ? velocity.z > 0 : playerAnimController.isFacingLeft());
                playerAnimController.WalkAnimation();
                //Debug.Log("Moving");
            }
            else
            {
                playerAnimController.IdleAnimation();
                Debug.Log("Idle");
            }
        }
        if (!isGrounded) playerAnimController.JumpAnimation();
    }


}
