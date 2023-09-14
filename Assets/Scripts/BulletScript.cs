using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private HealthBar _healthbar;
    [SerializeField] GameObject player;
    //Health health;


    void Awake()
    {
        //health = player.GetComponent<Health>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            //health.currentHealth = (health.maxHealth -= 1);
            Health.currentHealth--;
            
            Destroy(gameObject);
        }

        
    }

    /*void Update()
    {
        
    }*/
}