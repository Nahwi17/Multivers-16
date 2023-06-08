using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int hp = 110;
    int currentHealth;
    public Slider hpBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = hp;
        SetupHpBar(currentHealth);
    }
    
    public void SetupHpBar(int currentValue)
    {
        hpBar.value = currentValue;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }

        SetupHpBar(currentHealth);
    }

    void Die()
    {
        Debug.Log("enemy Died!");

        //Die Animation
        animator.SetBool("IsDead", true);

        GetComponent<Collider>().enabled = false;
        
        //Disable the enemy
        this.enabled = false;
        

    }
}
