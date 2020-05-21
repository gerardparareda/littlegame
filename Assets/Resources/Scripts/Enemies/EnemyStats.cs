using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    public delegate void DeathEventHandler(string name);
    public static event DeathEventHandler onEnemyDeath;
    public EnemyAnimationControl EnemyAnim;
    

    public void Start()
    {
        
    }
    public override void Die ()
    {
        base.Die();
        if (QuestCounter.instance.numberOfActiveKillGoal != 0)
        {
            onEnemyDeath(gameObject.name);
        }
        EnemyAnim.FallDown();
        //WaitToDie();
        //Add ragdoll efect
        //Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        EnemyAnim.AnimDamage();

        
    }

    IEnumerator WaitToDie()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}