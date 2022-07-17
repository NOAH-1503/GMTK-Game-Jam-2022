using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpHeight;
    //public float fallMultiplier;
    public float minFallSpeed;

    private float movement;

    private Rigidbody rb;

    public bool isJumping;
    bool facingRight;

    public GameManager gameManager;

    //public Animator ladderAnimator;

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

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector3(rb.velocity.x, jumpHeight, 0));
        }

        if (rb.velocity.y < minFallSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, minFallSpeed, rb.velocity.z);
        }

        //if (rb.velocity.y < 0)
        {
            //rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        //if (movement > 0 && !facingRight)
        {
            //Flip();
        }
        //else if (movement < 0 && facingRight)
        {
            //Flip();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
            rb.useGravity = false;
            rb.mass = 0f;
            rb.velocity = new Vector3(0, 0, 0);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            if (ScoreText.score != 0)
            {
                //ladderAnimator.SetBool("Ladderdown", true);
            }
        } 
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            //ladderAnimator.SetBool("Ladderdown", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
