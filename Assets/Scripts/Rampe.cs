using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rampe : MonoBehaviour
{
    PlayerMovement playerMovement;



    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerMovement.SpeedBoost();
        }
        // Accelerate the player on touch
    }

    void Update()
    {
        
    }
}
