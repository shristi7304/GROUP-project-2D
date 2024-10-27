using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GingerMan : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        
        if (transform.position.x > 10) 
        {
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Caught a Ginger Man!");
            Destroy(gameObject); 
        }
    }
}
