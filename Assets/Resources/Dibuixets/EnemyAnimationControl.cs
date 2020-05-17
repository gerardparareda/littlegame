﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    public Animator parentAnimator;
    public Animator childAnimator;

    private float time = 0f;
    private bool damaged = false;
    private bool damaged2 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 5f & !damaged)
        {
            Debug.Log("TakeDamage!");
            TakeDamage();
            damaged = true;
        }

        if (time > 7f & !damaged2) 
        {
            Debug.Log("TakeDamage!");
            TakeDamage();
            damaged2 = true;
        }

        if (time > 10f)
        {
            Debug.Log("FallDown!");
            FallDown();
        }
    }

    public void TakeDamage()
    {
        //parentAnimator.SetBool("damage", true);
        //childAnimator.SetBool("d", true);
        childAnimator.SetTrigger("New Trigger");
        parentAnimator.SetTrigger("damage_parent");

        //parentAnimator.SetBool("damage", false);
        //childAnimator.SetBool("d", false);
    }

    public void FallDown()
    {
        childAnimator.SetTrigger("fall_down");
    }
}
