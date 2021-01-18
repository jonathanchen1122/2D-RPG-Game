using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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



    public int health;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

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

        if (health < maxHealth && Input.GetKeyDown(KeyCode.P))
        {
            health += 1;
        }

        if (health > 0 && Input.GetKeyDown(KeyCode.L))
        {
            health -= 1;
        }
    }

    void FixedUpdate()
    {
        heartMethod();


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

    void heartMethod()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        // hearts

        for (int i = 0; i < hearts.Length; i++)
        {
            // actual current health
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // max health monitoring
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
