using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEditor;

public class PlayerAnimationController : MonoBehaviour
{

    public Animator playerAnimator;
    public bool isGrounded;
    public bool isMoving;
    public bool facingLeft;

    public bool isIdle;
    public bool isJumping;
    public PlayerState playerState;
    public enum PlayerState { idle, jumpingLeft, jumpingRight, movingLeft, movingRight}

    private float elapsed;
    private float elapsed2;

    private int aaa = 0;

    [Range(-1, 1)]
    public float velocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        elapsed2 += Time.deltaTime;

        if (elapsed > 2f)
        {
            //playerAnimator.SetBool("facingLeft", !playerAnimator.GetBool("facingLeft"));
            //playerAnimator.SetTrigger("movingLeft");
            //doA();
            elapsed = 0f;
        }
        /*
        if (elapsed2 > 4f)
        {
            playerAnimator.SetBool("isMoving", !playerAnimator.GetBool("isMoving"));
            playerAnimator.SetTrigger("movingRight");
            //elapsed2 = 0f;
        }

        if (elapsed2 + 2 > 4f)
        {
            //playerAnimator.SetBool("isGrounded", !playerAnimator.GetBool("isGrounded"));

        }*/

        /*if (elapsed2 > 4) playerAnimator.SetTrigger("movingRight");
        if (elapsed2 > 7 && elapsed < 7.1f) playerAnimator.SetTrigger("jumpLeft");
        if (elapsed2 > 10 && elapsed < 10.1f) playerAnimator.SetTrigger("jumpRight");*/

        //getInput();
    }

    public bool isFacingLeft()
    {
        return facingLeft;
    }

    public void doA()
    {
        switch (aaa)
        {
            case 0: 
                playerAnimator.SetTrigger("movingLeft");
                break;
            case 1:
                playerAnimator.SetTrigger("movingRight");
                break;
            case 2:
                playerAnimator.SetTrigger("idleLeft");
                break;
            case 3:
                playerAnimator.SetTrigger("idleRight");
                break;
            case 4:
                playerAnimator.SetTrigger("idleLeft");
                break;
            case 5:
                playerAnimator.SetTrigger("jumpLeft");
                break;
            case 6:
                playerAnimator.SetTrigger("idleLeft");
                playerAnimator.SetTrigger("jumpRight");
                break;
            case 7:
                playerAnimator.SetTrigger("idleRight");
                break;
            case 8:
                //playerAnimator.SetTrigger("jumpLeft");
                break;
            default:
                break;
        }

        aaa++;
    }

    public void aaaaa()
    {
        if (!isMoving && velocity != 0) playerAnimator.SetTrigger("movingLeft");
    }

    public void getInput()
    {
        if (Input.GetKeyDown(KeyCode.A)) playerAnimator.SetTrigger("movingLeft");
        if (Input.GetKeyDown(KeyCode.S)) playerAnimator.SetTrigger("movingRight");
        if (Input.GetKeyDown(KeyCode.D)) playerAnimator.SetTrigger("jumpLeft");
        if (Input.GetKeyDown(KeyCode.W)) playerAnimator.SetTrigger("jumpRight");
        if (Input.GetKeyDown(KeyCode.Space)) playerAnimator.SetTrigger("jumpLeft");
        if (Input.GetKeyDown(KeyCode.Q)) playerAnimator.SetTrigger("jumpLeft");
    }

    public void WalkLeftAnimation()
    {
        if (playerState == PlayerState.movingLeft) return;
        playerAnimator.SetTrigger("movingLeft");
        playerState = PlayerState.movingLeft;
    }

    public void WalkRightAnimation()
    {
        if (playerState == PlayerState.movingRight) return;
        playerAnimator.SetTrigger("movingRight");
        playerState = PlayerState.movingRight;
    }

    public void SetFacingLeft(bool isFacingLeft)
    {
        facingLeft = isFacingLeft;
    }

    public void JumpLeftAnimation()
    {
        playerAnimator.SetTrigger("jumpLeft");
    }

    public void JumpRightAnimation()
    {
        playerAnimator.SetTrigger("jumpRight");
    }

    public void IdleLeftAnimation()
    {
        playerAnimator.SetTrigger("idleLeft");
    }

    public void IdleRightAnimation()
    {
        playerAnimator.SetTrigger("idleRight");
    }

    public void IdleAnimation()
    {
        if (playerState == PlayerState.idle) return;
        if (facingLeft) IdleLeftAnimation();
        else IdleRightAnimation();
        playerState = PlayerState.idle;
    }

    public void JumpAnimation()
    {
        if (facingLeft && playerState != PlayerState.jumpingLeft)
        {
            JumpLeftAnimation();
            playerState = PlayerState.jumpingLeft;
        }
        else if (!facingLeft && playerState != PlayerState.jumpingRight)
        {
            JumpRightAnimation();
            playerState = PlayerState.jumpingRight;
        }
    }

    public void WalkAnimation()
    {
        if (playerState != PlayerState.movingLeft && facingLeft) WalkLeftAnimation();
        else if (playerState != PlayerState.movingRight && !facingLeft) WalkRightAnimation();

       
    }

}
