using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f; 
    public float jumpForce = 7.5f; 
    private Rigidbody2D rb;
    private bool isGrounded = false;

    private float currentSpeed; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed; 
    }

    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }

        // Check for Sugar Syrup or Slippery Floor
        if (collision.gameObject.CompareTag("SugarSyrup") || collision.gameObject.CompareTag("SlipperyFloor"))
        {
            currentSpeed = moveSpeed * 0.5f; // Reduce speed to 50% when in syrup or slippery floor
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Reset speed when leaving the syrup or slippery floor
        if (collision.gameObject.CompareTag("SugarSyrup") || collision.gameObject.CompareTag("SlipperyFloor"))
        {
            currentSpeed = moveSpeed; // Reset speed to normal when exiting
        }
    }
}