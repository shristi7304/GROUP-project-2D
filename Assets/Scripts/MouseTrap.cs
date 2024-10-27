using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public float trapDuration = 3f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                StartCoroutine(TrapPlayer(player));
            }
        }
    }

    private IEnumerator TrapPlayer(PlayerMovement player)
    {
        player.enabled = false; 
        yield return new WaitForSeconds(trapDuration); 
        player.enabled = true; 
    }
}
