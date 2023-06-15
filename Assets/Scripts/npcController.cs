// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// // [RequireComponent(typeof(Animator))]
// // [RequireComponent(typeof(NavMeshAgent))]

// public class npcController : MonoBehaviour
// {
//     [Header("Component")]
//     public slider healthSlider;
//     private Animator animator;
//     private Animator animator;
//     private NavMeshAgent navMeshAgent;
//     private GameObject playerObject;
    
// //     [Header("Values")]
// //     public float roamCooldownTime = 10;
// //     public float maxRoamDistance; 
// //     public float health;

//     [HideInspector]public int characterState;
//     private float horizontal , vertical;
//     private float RoamTimer;
//     private float velocity = 0;
//     private bool stateChangedFlag = false; // used once to change state of player

//     // Start is called before the first frame update
//     void Start()
//     {
//         animator = GetComponent<Animator>();
//         navMeshAgent = GetComponent<NavMeshAgent>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         animations();
//         Roam();
//     }

// //     void Roam()
// //     {
// //         if(characterState != 0)return;

// //         if(Time.time > RoamTimer)
// //         {
// //             float a = Random.Range(0,2);
// //             RoamTimer = Time.time + 10;
// //             navMeshAgent.SetDestination(new Vector3(transform.position.x + Random.Range(maxRoamDistance/2 , maxRoamDistance) * (a == 1 ? 1 : -1),0
// //             ,transform.position.x + Random.Range(maxRoamDistance/2 , maxRoamDistance) * (a == 1 ? 1 : -1)));
// //         }
        
// //     }

// //     void animations(){
// //         animator.SetFloat("Vertical", vertical);
// //         animator.SetFloat("horizontal", horizontal);
// //         animator.SetFloat("state", characterState);
// //     }

// //     string getCharState(){
// //         switch(characterState){
// //             case 0:
// //                 return "peaceful";
// //             break;
// //             case 1:
// //                 return "Combat";
// //             break;
// //         }
// //         return"out of range";
// //     }

//     public void receiveDamage(float value)
//     {
//         animator.SetTrigger("takeDamage")
//     }

// // //     public void receive

// // //     // void OnGui()
// // //     // {
// // //     //     GuIjdbvdjbksdabhfdijweoqpq[slxm cjldfar4poeqrjfior13bgyebncl;smdnvjhklsnbsdlgftygudjb VHJ43QYU0EMD C©B]
// // //     // }
// // }
