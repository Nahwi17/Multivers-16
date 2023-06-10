using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    
    // pulic bTransform attackPoint;
    public LayerMask Player;

    public float attackRange, distance;
    public int attackDamage = 15;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 4f)
            animator.SetBool("isAttacking", false);

        //detect enemy in range attack 
        // Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, Player);

        //damage them 
        // foreach(Collider player in hitPlayer)
        // {
        //     player.GetComponent<Player>().TakeDamage(attackDamage);
        //     Debug.Log("We Hit" + player.name);
        // }
    
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    // override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //    // Implement code that processes and affects root motion
    // }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}


    // public Transform attackPoint;
    // public LayerMask Player;

    // public float attackRange = 0.5f;
    // public int attackDamage = 15;
       

    //     //detect enemy in range attack 
    //     Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

    //     //damage them 
    //     foreach(Collider enemy in hitEnemies)
    //     {
    //         enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
    //         Debug.Log("We Hit" + enemy.name);
    //     }
    

//     void OnDrawGizmosSelected() 
//     {
//         if (attackPoint == null)
//             return;

//         Gizmos.DrawWireSphere(attackPoint.position, attackRange);    
//     }
// }
