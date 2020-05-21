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
      
        //Add ragdoll efect
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        EnemyAnim.AnimDamage();

        
    }

}