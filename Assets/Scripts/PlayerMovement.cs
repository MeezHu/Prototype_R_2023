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

    public ParticleSystem SpeedCap;


    private void FixedUpdate ()
    {
        if (!alive) return;

        speed = speed += speedIncrease * Time.deltaTime;
        if (speed >= 60)
        {
            speed = 60;

        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

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

        if (speed >= 29)
        {
            SpeedCap.Play();

        }
        else
        {
            SpeedCap.Stop();
        }

    }


    

    public void BumpVariable()
    {
        speed = -5;
    }

    public void SpeedBoost()
    {
        speed += 5;
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }



}
