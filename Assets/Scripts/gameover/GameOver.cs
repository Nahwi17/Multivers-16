using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance{ get; set; }

    public Button ButtonRespawn;
    public Button ButtonGotoMainMenu;
    public Canvas gameOverUI;
    public bool isGameOverUIShown;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        
        else
        {
            Instance = this;
        }
    }

    public void ShowGameOverUI()
    {
        gameOverUI.gameObject.SetActive(true);
        isGameOverUIShown = true;

        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
    }

    public void HideGameOverUI()
    {
        gameOverUI.gameObject.SetActive(false);
        isGameOverUIShown = false;

        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }
}
