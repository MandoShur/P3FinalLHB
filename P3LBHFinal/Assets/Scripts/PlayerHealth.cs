using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
  
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText; //text component reference
    public GameOverManager gameOverManager; // Reference to the GameOverManager
    public GameManager gameManager;


    public GameTimer gameTimer;

    void Start()
    {
        UpdateHealthText();
        currentHealth = maxHealth;

        if (healthText == null)
        {
            UnityEngine.Debug.LogError("HealthText reference is not set in the Inspector!");
            return;
        }

    }

    public void TakeDamage(int amount)
    {
    
        currentHealth -= amount;
        // Clamp the current health to be within 0 and maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // Update the health 
        UpdateHealthText();
        if (currentHealth <= 0)
        { 
            Die();
        }

        if (currentHealth <= 0)
        {
            gameOverManager.GameOver();
        }
    }

    void Die()
    {
        if (gameTimer != null)
        {
            gameTimer.StopTimer();
        }

        if (gameManager != null)
        {
            gameManager.GameOver(); // Call GameOver method from GameManager
        }
        else
        {
            UnityEngine.Debug.LogError("GameManager reference not set on PlayerHealth script.");
        }

        UnityEngine.Debug.Log("Player died!");
        // Add other death logic here (e.g., show game over screen)
    }


    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }

        else
        {
            UnityEngine.Debug.LogError("HealthText reference is missing!");
        }
    }
    
    

    public void Heal(int amount)
    {
        // Increase current health by amount healed
        currentHealth += amount;
        // Clamp the current health to be within 0 and maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // Update the health display
        UpdateHealthText();
    }
}