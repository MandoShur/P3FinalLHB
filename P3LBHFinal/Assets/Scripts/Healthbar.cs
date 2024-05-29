using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    // Set max value of the healthbar
    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth; // Set value to max
    }

    // Update the health of the slider
    public void SetHealth(float health)
    {
        slider.value = health;
    }

    // Decrease health when taking damage
    public void DecreaseHealth(float health)
    {
        slider.value -= health;
    }
}
