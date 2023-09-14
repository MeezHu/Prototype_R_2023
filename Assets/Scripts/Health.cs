using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public static int currentHealth;
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;

    }

    private void Update()
    {
        death();
    }

    public void death()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

}
