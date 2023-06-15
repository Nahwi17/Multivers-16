using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player menerima serangan dan kehilangan " + damage + " poin darah.");

        if (currentHealth <= 0)
        {
            Debug.Log("Player telah terbunuh.");
            // Tambahkan aksi yang diinginkan ketika player mati
        }
    }
}


