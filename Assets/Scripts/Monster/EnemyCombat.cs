// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;

// public class EnemyCombat : MonoBehaviour
// {
//     public PlayerHealth playerHealth;
//     public int attackDamage = 17;

//     public Transform attackPoint;
//     public LayerMask playerLayers;
//     void Start()
//     {

//     }

//     void Update() 
//     {

//     }

//     void Attack ()
//     {
//         //play on atttack animation
//         // animator.SetTrigger("Attack");

//         //detect enemy in range attack 
//         Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);

//         //damage them 
//         foreach(Collider player in hitPlayer)
//         {
//             player.GetComponent<Player>().TakeDamage(attackDamage);
//             Debug.Log("We Hit" + player.name);
//         }
//     }
//     // private void OnCollisionEnter(Collision collision) 
//     // {
//     //     if(collision.GameObject.tag == "Player")
//     //     {
//     //         playerHealth.TakeDamage(damage);
//     //     }    
//     // }
// }
