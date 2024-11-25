using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 7.5f;
    public int health = 3;
    public int maxHealth = 3;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Vector3 respawnPosition;
    public PlayerHealth playerHealthUI;

    public float minX = -283.1f; 
    public float maxX = 356.9f; 
    public float minY = -4.4f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPosition = transform.position; 
        playerHealthUI.SetHealth(health);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        ClampPlayerWithinBoundaries();
    }

    private void ClampPlayerWithinBoundaries()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Max(transform.position.y, minY);  
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Reset position if the player touches a hazard
        if (other.CompareTag("Hazard"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        playerHealthUI.SetHealth(health);
        Debug.Log("Player health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has Died!");
    }

    public void GainHealth(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
         playerHealthUI.SetHealth(health); 
        Debug.Log("Player gained health. Current health: " + health);
    }

}

