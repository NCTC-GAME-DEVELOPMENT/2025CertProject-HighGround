using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public HealthSystem playerHealth;

    private void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        SetMaxHealth(playerHealth.maxHealth); 
        SetHealth(playerHealth.currentHealth); 

    }

    private void Update()
    {
        SetHealth(playerHealth.currentHealth);
    }

    public void SetMaxHealth(float maxHealth)
    {
        healthBar.maxValue = maxHealth;
    }


    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}