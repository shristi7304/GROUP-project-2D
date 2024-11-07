using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour

{
    public int healthAmount = 1; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NewBehaviourScript player = collision.GetComponent<NewBehaviourScript>();
            if (player != null)
            {
                player.GainHealth(healthAmount); 
            }
            
            Destroy(gameObject);
        }
    }
}