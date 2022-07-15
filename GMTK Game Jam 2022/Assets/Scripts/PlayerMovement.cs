using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpHeight;
    public float fallMultiplier;

    private float movement;

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate = 2f;
    float nextFireTime = 0f;

    private Rigidbody rb;

    bool isJumping;
    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(runSpeed * movement, rb.velocity.y, 0);

        //if (Input.GetButton("Fire1"))
        {
            //if (Time.time >= nextFireTime)
            {
                //Instantiate(bullet, firePoint.position, firePoint.rotation);
                //nextFireTime = Time.time + 1f / fireRate;
            }
        }

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector3(rb.velocity.x, jumpHeight, 0));
        }

        if (rb.velocity.y < 5)
        {
            rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (movement > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
