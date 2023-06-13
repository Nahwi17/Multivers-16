using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask layers;
    public AudioSource audioSource;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 1.5f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            // if (Input.GetButtonDown("Fire2"))
            // {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                // audioSource.enabled = true;
                // audioSource.Play();
            // }
        }
        
    }

    void Attack ()
    {
        //play on atttack animation
        // animator.SetTrigger("Attack");

        //detect enemy in range attack 
        Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange, layers);

        //damage them 
        foreach(Collider enemy in hitPlayers)
        {
            enemy.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Debug.Log("Musuh hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);    
    }
}
