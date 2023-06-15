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
    // public nagaKebon;
    public AudioSource hurt, death, napas;
    public GameObject Naga;

    public PlayerData data;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public LayerMask playerLayers;
    private float countdownTimer = 5f;
    private bool isCountingDown = false;
    private bool isAttacking = false;

    public GameObject dropItem;
    public int dropCount;

    //damage ke player 
    GameObject playerStatus;

    //void Awake()
    //{
    //    hpBar = GetComponent<Slider>();    
    //}

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = hp;
        SetupHpBar(currentHealth);

        //menemuakan collider player
        data = FindObjectOfType<PlayerData>();
    }
    public void Update()
    {

        //currentHealth = playerStatus.GetComponent<PlayerStatus>().hp;
      

        //float fillValue = currentHealth / hp;
        //hpBar.value = currentHP;

        StartCoroutine(Attack());
    //if (!isAttacking)
    //    {
            
        //}
        
    }
    IEnumerator Attack()
    {
        if(!isAttacking)
        {
            isAttacking = true;
            yield return new WaitForSeconds(2f);
            //data.Attacking(Random.Range(minDamage, maxDamage));
            isAttacking = false;
        }
        
    }
    void Attacking()
    {
        //play on atttack animation
        animator.SetTrigger("Attack");

        //detect enemy in range attack 
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);

        //damage them 
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("We Hit" + enemy.name);
        }
    }
    public void SetupHpBar(int currentValue)
    {
        hpBar.value = currentValue;
    }


    public void TakeDamage(int damage)
    {
        //if (!isAttacking)
        
            //isAttacking = true;
            //yield return new WaitForSeconds(2f);
            //data.TakeDamage(Random.Range(minDamage, maxDamage));
            //isAttacking = false;
        
        currentHealth -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");
        hurt.enabled = true;
        hurt.Play();

        if(currentHealth <= 0)
        {
            Die();
            // nagaKebon.enabled = false;
            
        }

        SetupHpBar(currentHealth);
    }

    void Die()
    {
        Debug.Log("enemy Died!");

        //Die Animation
        animator.SetBool("IsDead", true);
        death.enabled = true;
        death.Play();
        napas.enabled = false;


        GetComponent<Collider>().enabled = false;
        
        //Disable the enemy
        this.enabled = false;
        for (int i = 0; i < dropCount; i++)
        {
             DropObject();
        }
       
        //Naga.SetActive(false);
    }
    
    public void DropObject()
    {
        GameObject tmpObject = Instantiate(dropItem);
        tmpObject.transform.position = this.transform.position;
    }

}

