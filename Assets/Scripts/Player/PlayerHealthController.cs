using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public float currentHealth, maxHealth;

    public Slider healthSlider;

    public GameObject deathEffect;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void UpdateHealth(float change)
    {
        currentHealth += change;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);

            LevelManager.instance.EndLevel();

            Instantiate(deathEffect, transform.position, transform.rotation);
        }

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthSlider.value = currentHealth;
    }

    

}
