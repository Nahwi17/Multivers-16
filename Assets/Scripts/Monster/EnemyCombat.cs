using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public bool playerInRange = false;

    int interval = 1;
    float nextTime = 0;
    public Collider demegenemy;

   

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextTime)
        {

            //do something every interval seconds
            if (playerInRange)
            {
                PlayerStatus.Instance.currentHP -= 6;
                PlayerStatus.Instance.SetupHpBar(PlayerStatus.Instance.currentHP);
            }

            nextTime += interval;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Die()
    {
        Debug.Log("damage enemy null");


        GetComponent<Collider>().enabled = false;
        //Naga.SetActive(false);
    }



    //public Animator animator;

    //public Transform attackPoint;
    //public LayerMask layers;
    //public AudioSource audioSource;

    //public float attackRange = 0.5f;
    //public int attackDamage = 40;

    //public float attackRate = 1.5f;
    //float nextAttackTime = 0f;

    // Update is called once per frame
    //void Update()
    //{
    //    if(Time.time >= nextAttackTime)
    //    {
    //        // if (Input.GetButtonDown("Fire2"))
    //        // {
    //            Attack();
    //            nextAttackTime = Time.time + 1f / attackRate;
    //            // audioSource.enabled = true;
    //            // audioSource.Play();
    //        // }
    //    }

    ////}

    //void Attack ()
    //{
    //    //play on atttack animation
    //    // animator.SetTrigger("Attack");

    //    //detect enemy in range attack 
    //    Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange, layers);

    //    //damage them 
    //    foreach(Collider enemy in hitPlayers)
    //    {
    //        enemy.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    //        Debug.Log("Musuh hit " + enemy.name);
    //    }
    //}

    //void OnDrawGizmosSelected() 
    //{
    //    if (attackPoint == null)
    //        return;

    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);    
    //}
}
