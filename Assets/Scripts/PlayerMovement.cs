using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Animator playerAnim;

    public float walkSpeed = 10f;
    public float sprintSpeed = 20f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private CinemachineVirtualCamera virtualCamera;

    Vector3 velocity;
 
    bool isGrounded;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
      
      //Sprinting
         
        if (Input.GetKeyDown(KeyCode.LeftShift))
             
        {
            walkSpeed = sprintSpeed;
        }
         else
         
        {
            walkSpeed = walkSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = 10f;
        }
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 cameraForward = virtualCamera.transform.forward;
        Vector3 cameraRight = virtualCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();
 
        //right is the red Axis, foward is the blue axis
        // Vector3 move = transform.right * x + transform.forward * z;
        Vector3 move = cameraForward * z + cameraRight * x;
 
        controller.Move(move * walkSpeed * Time.deltaTime);
 
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
 
        velocity.y += gravity * Time.deltaTime;
 
        controller.Move(velocity * Time.deltaTime);

        if (move.magnitude > 0f)
        {
            Quaternion toRotation = Quaternion.LookRotation(cameraForward);
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, toRotation, 0.15f));
        }
    }
}



// using UnityEngine;
// using Cinemachine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f;

//     private Rigidbody rb;
//     private CinemachineVirtualCamera virtualCamera;

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
//     }

//     private void Update()
//     {
//         float moveX = Input.GetAxis("Horizontal");
//         float moveZ = Input.GetAxis("Vertical");

//         Vector3 cameraForward = virtualCamera.transform.forward;
//         Vector3 cameraRight = virtualCamera.transform.right;

//         cameraForward.y = 0f;
//         cameraRight.y = 0f;
//         cameraForward.Normalize();
//         cameraRight.Normalize();

//         Vector3 movement = (cameraForward * moveZ + cameraRight * moveX) * moveSpeed * Time.deltaTime;
//         rb.MovePosition(transform.position + movement);

//         if (movement.magnitude > 0f)
//         {
//             Quaternion toRotation = Quaternion.LookRotation(cameraForward);
//             rb.MoveRotation(Quaternion.Lerp(rb.rotation, toRotation, 0.15f));
//         }
//     }
// }


//   if (Input.GetKeyDown(KeyCode.W))
//         {
//             playerAnim.SetTrigger("walk");
//             playerAnim.ResetTrigger("idle");
            
//         }

//         if (Input.GetKeyUp(KeyCode.W))
//         {
//             playerAnim.ResetTrigger("walk");
//             playerAnim.SetTrigger("idle");
            
//         }
//         if (Input.GetKeyDown(KeyCode.S))
//         {
//             playerAnim.SetTrigger("walkback");
//             playerAnim.ResetTrigger("idle");
//         }

//         if (Input.GetKeyUp(KeyCode.S))
//         {   
//             playerAnim.ResetTrigger("walkback")
//             playerAnim.SetTrigger("idle");
//         }
