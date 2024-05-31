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
    public TextMeshProUGUI healthText; 
    public GameOverManager gameOverManager; 
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
            gameManager.GameOver(); // Call GameOver method from the game manager
        }
        else
        {
            UnityEngine.Debug.LogError("GameManager reference not set on PlayerHealth script.");
        }

        UnityEngine.Debug.Log("Player died!");
       
    }


    void UpdateHealthText()
    {
        //updates health onto the text
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }

        else
        {
            UnityEngine.Debug.LogError("HealthText reference is missing!");
        }
    }
    
    


}