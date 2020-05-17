using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{

    public int MaxHealth = 100;
    public int CurrentHealth { get; set; }
    public Stat damage;
    public Stat armor;

    public Image healthBar;

    private void Awake()
    {
        CurrentHealth = MaxHealth;        
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }*/
    }
    public virtual void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log(transform.name + "Takes damage" + damage);
        HealthUpdate();

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void HealthUpdate()
    {
        Debug.Log("currentHealth:" + CurrentHealth + ".   MaxHealth: " + MaxHealth);
        float a = (float)CurrentHealth / (float)MaxHealth;
        Debug.Log(a);
        healthBar.fillAmount = a;
    }

    public virtual void Die ()
    {
        //Die in some way
        Debug.Log(transform.name + " died.");
    }


}
