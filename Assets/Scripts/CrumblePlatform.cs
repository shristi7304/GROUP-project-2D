using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblePlatform : MonoBehaviour
{
    private bool isPlaced = false; 
    private float crumbleTime = 5f; 

    private void Start()
    {
    
        isPlaced = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlaced && other.CompareTag("Player"))
        {
            StartCoroutine(Crumble());
        }
    }

    private IEnumerator Crumble()
    {
        // Wait for the crumble time to pass
        yield return new WaitForSeconds(crumbleTime);

        // Play crumble animation or any effects (optional)
        // Example: PlayAnimation();

        // Destroy the platform after 5 seconds
        Destroy(gameObject);
        Debug.Log("Platform has crumbled!");
    }
}