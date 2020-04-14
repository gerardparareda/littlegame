using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int MaxHealth = 100;
    public int CurrentHealth { get; private set; }
    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log("Takes damage" + damage);

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die ()
    {
        //Die in some way
        Debug.Log(transform.name + " died.");
    }


}
