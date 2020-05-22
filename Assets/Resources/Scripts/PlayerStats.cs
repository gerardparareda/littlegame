using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{

 
    public override void Die()
    {
        base.Die();
        SceneManager.LoadScene(2);
    }

    public void gainHealth(int health)
    {

        CurrentHealth += health;
        HealthUpdate();
    }

}
