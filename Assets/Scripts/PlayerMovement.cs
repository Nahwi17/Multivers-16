using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerMovement : MonoBehaviour
{
    [Header("character weapon")]
    public GameObject weapon;
    public int characterState = 0;
    // private gameManager manager;
    [Header("character component")]
    public CharacterController controller;

    // public Inventory inventory;

    public Animator playerAnim;

    public float walkSpeed = 4f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public float sprintSpeed = 8f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 2f;
    public Vector3 move;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform cam;
    
    

    private Rigidbody rb;
    private CinemachineVirtualCamera virtualCamera;
    private Animator anim;
    

    Vector3 velocity;
 
    bool isGrounded;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // anim = GetComponent<Animator>();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        // manager = FindObjectOfType<gameManager>();
        // if(manager == null) print("No manager in scene");

        // spawnWeapon();

    }

    // void spawnWeapon()
    // {
    //     if(characterState == 1)
    //     {
    //         GameObject mele = Instantiate(manager.meleWeapons.GetComponent<meleWeapons>().weapons[PlayerPrefs.GetInt("currentWeaponIndex")]);
    //         mele.transform.parent = weapon.transform;
    //         mele.transform.localPosition = Vector3.zero;
    //         // mele.transform.localEularAngles = Vector3.zero;
    //         mele.transform.localScale = new Vector3(1,1,1);
    //     }
    // }
    void Update()
    {
        // //weapons
        // if(Input.GetKeyDown(KeyCode.R))
        // {
        //     spawnWeapon();
        // }
      
      //Sprinting
         
        if (Input.GetKeyDown(KeyCode.LeftShift))
             
        {
            walkSpeed = sprintSpeed;
            playerAnim.SetBool("sprint", true);

        }
         else
         
        {
            walkSpeed = walkSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = 4f;
            playerAnim.SetBool("sprint", false);

        }

        if(move != Vector3.zero)
        {
           playerAnim.SetBool("walk",true);  
        }
        else
        {
            playerAnim.SetBool("walk",false);
        }

        // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        // {
        //     playerAnim.SetBool("walk",true);
            
        // }
        // if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
        // {
        //     playerAnim.SetBool("walk",false); 
        // }

        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
 
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = virtualCamera.transform.forward;
        Vector3 cameraRight = virtualCamera.transform.right;
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();
 
        //right is the red Axis, foward is the blue axis
        // Vector3 move = transform.right * x + transform.forward * z;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * walkSpeed * Time.deltaTime);
        }

        move = cameraForward * z + cameraRight * x;
        
        
 
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            playerAnim.SetTrigger("Jump");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (move.magnitude > 0f)
        {
            Quaternion toRotation = Quaternion.LookRotation(cameraForward);
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, toRotation, 0.15f));
        }
    }

    // private void OnControllerColliderHit(ControllerColliderHit hit) 
    // {
    //     IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
    //     if(item != null)
    //     {
    //         inventory.AddItem(item);
    //     }
    // }

}

