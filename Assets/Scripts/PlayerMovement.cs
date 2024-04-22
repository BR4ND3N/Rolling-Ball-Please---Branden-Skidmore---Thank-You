using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;

    private Rigidbody playerRb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rayDistance;

    public bool isPoweredUp;
    public float powerBounceStrength;
    public float powerupTime = 7f;

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, rayDistance);
    }


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * playerSpeed;
        float moveZ = Input.GetAxis("Vertical") * playerSpeed;

        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);

        if (movement.magnitude > 0.1)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            playerRb.AddForce(moveDir * playerSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (isGrounded() == true) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            isPoweredUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

   IEnumerator PowerUpCountDownRoutine()
   {
        yield return new WaitForSeconds(powerupTime);
        isPoweredUp = false;
   }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPoweredUp == true)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 bounceDir = (collision.gameObject.transform.position - transform.position);
            enemyRb.AddForce(bounceDir * powerBounceStrength, ForceMode.Impulse);
        }
    }
}
