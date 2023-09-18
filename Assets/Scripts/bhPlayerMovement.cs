using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bhPlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 10;

    public float lookSmooth = 0.05f;

    public float directionSmooth = 0.02f;

    private Vector3 inputDirection = Vector3.zero;

    private Vector3 effectiveDirection = Vector3.zero;

    public bool dashing = true;
    private float dashingPower = 2.2f;
    private float dashingTime = 0.1f;
    //private float dashingCooldown = 0.1f;

    [SerializeField] private TrailRenderer tr;





    void Start()
    {
        characterController = GetComponent<CharacterController>();

        tr.emitting = false;

    }

    void Update()
    {
        float movementHorizontal = Input.GetAxisRaw("Horizontal");
        float movementVertical = Input.GetAxisRaw("Vertical");

        inputDirection.x = movementHorizontal;
        inputDirection.z = movementVertical;
        inputDirection.Normalize();

        if (inputDirection.magnitude > 0.01)
        {
            float lookAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            float effectiveAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.y, lookAngle, lookSmooth);
            transform.rotation = Quaternion.Euler(0, effectiveAngle, 0);
        }

        effectiveDirection = Vector3.Lerp(effectiveDirection, inputDirection, directionSmooth);
        characterController.Move(effectiveDirection * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && dashing)
        {
            Debug.Log("Dashing");
            StartCoroutine(Dash());
        }

    }

    private IEnumerator Dash()
    {
        dashing = true;
        tr.emitting = true;

        effectiveDirection = new Vector3(transform.forward.x * dashingPower, 0f, transform.forward.z * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        effectiveDirection = Vector3.zero;
        tr.emitting = false;
        /*yield return new WaitForSeconds(dashingCooldown);
        dashing = true;*/
    }
}
