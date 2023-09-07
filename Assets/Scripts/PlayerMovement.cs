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

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


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

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }

}
