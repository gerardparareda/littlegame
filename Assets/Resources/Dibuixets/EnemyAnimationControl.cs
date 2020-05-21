using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    public Animator parentAnimator;
    public Animator childAnimator;

    public bool facingLeft;
    public PlayerState enemyState;

    private float time = 0f;
    private bool damaged = false;
    private bool damaged2 = false;

    public enum PlayerState { idle, walking, attacking, falling, takingDamage };
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        time += Time.deltaTime;

        if (time > 5f & !damaged)
        {
            Debug.Log("TakeDamage!");
            AnimDamage();
            damaged = true;
        }

        if (time > 7f & !damaged2) 
        {
            Debug.Log("TakeDamage!");
            AnimDamage();
            damaged2 = true;
        }

        if (time > 10f)
        {
            Debug.Log("FallDown!");
            FallDown();
        }
    }*/

    public void AnimDamage()
    {
        if (enemyState == PlayerState.takingDamage) return;
        childAnimator.SetTrigger("New Trigger");
        parentAnimator.SetTrigger("damage_parent");
        enemyState = PlayerState.idle;
    }

    public void FallDown()
    {
        if (enemyState == PlayerState.falling) return;
        childAnimator.SetTrigger("fall_down");
        enemyState = PlayerState.falling;
    }

    public void AnimWalk()
    {
        if (enemyState == PlayerState.walking) return;
        childAnimator.SetTrigger("walk");
        enemyState = PlayerState.walking;

    }
     
    public void AnimKick()
    {
        if (enemyState == PlayerState.attacking) return;
        childAnimator.SetTrigger("kick");
        enemyState = PlayerState.attacking;
    }
}
