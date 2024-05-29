using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar; 

    public GameTimer gameTimer;

    void Start()
    {
        currentHealth = maxHealth;
        if (slider != null)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth; // Set value to max
        }
        else
        {
            UnityEngine.Debug.LogError("Slider reference is not assigned in PlayerHealth script!");
        }
    }

    public void TakeDamage(int amount)
    {
    
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
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