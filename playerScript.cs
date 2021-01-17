using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private float moveInput;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask groundLayer;

    public float jumpForce;

    private float jumpTimeCounter;
    public float jumpTime;

    private bool isJumping;

    void Update()
    {

        //jumping

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);

        if ( isGrounded == true) {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }
         }

        // Long Jumping

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            if (isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }

                else {
                    isJumping = false;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }


        //flipping
        if (facingRight == true && moveInput < 0) // facing Right going Left
        {
            flip();
        }

        if (facingRight == false && moveInput > 0) // facing Left going Right
        {
            flip();
        }
    }

    void FixedUpdate()
    {
        // left Right movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput*speed,rb.velocity.y);
    }


    void flip()
    {
        facingRight = !facingRight;

        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
