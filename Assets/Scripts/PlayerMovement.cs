using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerMovement playerMovement;

    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;
    public Vector3 targetPos = Vector3.zero;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    public float speedIncrease = 1f;

    /*private void speedIncreaseCap()
    {
        speed = speed += speedIncrease * Time.deltaTime;

    }*/

    private void FixedUpdate ()
    {
        if (!alive) return;

        speed = speed += speedIncrease * Time.deltaTime;
        if (speed >= 30)
        {
            speed = 30;
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        /*float rightBoundary = 2f;
        if (transform.position.x >= rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, 0);
        }*/



        /*if (transform.position.x > 2)
        {
            targetPos = transform.position;
            targetPos.x = 2;
            transform.position = targetPos;
        }
        if (transform.position.x < -2)
        {
            targetPos = transform.position;
            targetPos.x = -2;
            transform.position = targetPos;
        }*/
    }


    void Start()
    {
        
    }

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        
    }

    /*public void Die()
    {
        alive = false;
        // Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    /*public void BumpForce()
    {
        rb.AddForce(new Vector3(0f, 0f, 0f));
    }*/

    public void BumpVariable()
    {
        speed = -10;
    }

}
