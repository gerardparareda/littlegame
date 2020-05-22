using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class EnemyStats : CharacterStats
{
    public delegate void DeathEventHandler(string name);
    public static event DeathEventHandler onEnemyDeath;
    public EnemyAnimationControl EnemyAnim;


    public void Start()
    {

    }
    public override void Die()
    {
        base.Die();
        if (QuestCounter.instance.numberOfActiveKillGoal != 0)
        {
            onEnemyDeath(gameObject.name);
        }
        EnemyAnim.FallDown();
        StartCoroutine(WaitToDie());
        //WaitToDie();
        //Add ragdoll efect
        
    }

    public override void TakeDamage(int damage)
    {
        Debug.Log("Enemic sent atacat");
        base.TakeDamage(damage);
        EnemyAnim.AnimDamage();


    }

    IEnumerator WaitToDie()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        //Destroy(gameObject);
        GetComponent<NavMeshAgent>().enabled = false;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}