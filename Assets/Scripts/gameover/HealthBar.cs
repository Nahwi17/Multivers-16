using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Text healthCounter;

    public GameObject playerState;
    public GameObject Player;

    private float currentHealth, maxHealth;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerState.GetComponent<PlayerStatus>().currentHP;
        maxHealth = playerState.GetComponent<PlayerStatus>().hp;

        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;

        healthCounter.text = currentHealth + "/" + maxHealth;

        
    }

    public void TakeDamage(int amount)
    {
	    PlayerStatus.Instance.currentHP -= amount;
        
        if (PlayerStatus.Instance.currentHP <= 0)
	    {
		    Die();
	    }
    }

    public void Die()
    {
        // set trigger animator die

	    // destroy
	    // Destroy(Player);

	    // show player die dialog (go to main menu/respawn)
        GameOver.Instance.ShowGameOverUI();

	    // add listener to buttons
        GameOver.Instance.ButtonRespawn.onClick.AddListener(()=> {
            GameOver.Instance.HideGameOverUI();
            RespawnPlayer.Instance.RespawnPlayerToPoint();
        });

        GameOver.Instance.ButtonGotoMainMenu.onClick.AddListener(()=> {
            GameOver.Instance.HideGameOverUI();
            SceneManager.LoadScene("Main Menu");
        });
	    //
    }
}
