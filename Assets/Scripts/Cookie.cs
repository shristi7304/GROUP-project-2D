using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    public float moveSpeed = 2f;
    private int moveDirection = 1; // 1 for right, -1 for left
    public LayerMask wallLayer; // LayerMask for detecting walls
    private float rayDistance = 0.1f; 

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * moveDirection * Time.deltaTime);

        if (IsWallAhead())
        {
            moveDirection *= -1; 
        }
    }

    private bool IsWallAhead()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.right * moveDirection;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, rayDistance, wallLayer);
        return hit.collider != null; 
    }
}