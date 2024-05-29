using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameTimer gameTimer;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameTimer != null)
        {
            gameTimer.StopTimer();
        }

        UnityEngine.Debug.Log("Player died!");
        // Add other death logic here (e.g., show game over screen)
    }
}