using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int RcurrentHealth;
    public static int currentHealth;
    //public Image healthBar;
    //[SerializeField] private HealthBar healthbar;

    public Slider healthbarUI;

    void Start()
    {
        currentHealth = maxHealth;

        //healthbar.UpdateHealthBar(maxHealth, currentHealth);

    }

    private void Update()
    {
        UpdateHealthBar();

        death();
    }

    public void UpdateHealthBar()
    {
        healthbarUI.value = currentHealth;
    }

    public void death()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    

}
