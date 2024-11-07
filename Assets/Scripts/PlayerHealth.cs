using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBoxImage;
    public List<Image> heartImages;  
    public int maxHealth = 5;        
    private int playerHealth;
    private bool canTakeDamage = true;  
    public float damageCooldown = 1f;   
    private void Start()
    {
        playerHealth = maxHealth;
        UpdateHearts();
    }

    public void SetHealth(int health)
    {
        playerHealth = health;
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            heartImages[i].enabled = i < playerHealth;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (canTakeDamage && playerHealth > 0)
        {
            playerHealth -= damageAmount;
            playerHealth = Mathf.Max(playerHealth, 0);  
            UpdateHearts();

            if (playerHealth <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(DamageCooldown());
            }
        }
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }

    private void Die()
    {
        Debug.Log("Player died!");
    }
}