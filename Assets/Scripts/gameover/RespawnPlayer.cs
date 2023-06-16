using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnPlayer : MonoBehaviour
{
    public static RespawnPlayer Instance{ get; set; }

    public CharacterController controller;
    
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

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
    
    public void RespawnPlayerToPoint()
    {
        //Player.transform.localPosition = Vector3.zero;
        controller.enabled = false;
        Player.transform.position = respawnPoint.transform.position;
        PlayerState.Instance.currentHealth = PlayerState.Instance.maxHealth;
        controller.enabled = true;
        Debug.Log("player respawn");
    }
}
