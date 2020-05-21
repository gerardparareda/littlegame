using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{

 
    public override void Die()
    {
        base.Die();
    }

    public void gainHealth(int health)
    {

        CurrentHealth += health;
        HealthUpdate();
    }

}
