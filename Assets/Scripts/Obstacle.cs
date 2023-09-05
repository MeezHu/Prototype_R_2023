using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        
    }

    /*    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Player")
            {
                playerMovement.Die();
            }
            // Kill the player
        }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerMovement.BumpVariable();
        }
        // Bump backwards the player
    }

    void Update()
    {
        
    }
}
