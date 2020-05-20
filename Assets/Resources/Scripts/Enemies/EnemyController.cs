﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
        
        if (distance <= agent.stoppingDistance)
        {
            //attack
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            if (targetStats != null)
            {
                combat.Attack(targetStats);
            }
          
            
        }
    }

    void FaceTarget ()
    {
        float direction = (target.position.z - transform.position.z);
        if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
