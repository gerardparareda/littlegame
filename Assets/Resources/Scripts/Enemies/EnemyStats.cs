using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public delegate void DeathEventHandler(string name);
    public static event DeathEventHandler onEnemyDeath;
    public override void Die ()
    {
        base.Die();
        onEnemyDeath(gameObject.name);
        //Add ragdoll efect
        Destroy(gameObject);
    }
}