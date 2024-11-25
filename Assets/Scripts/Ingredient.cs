using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredientName; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the ingredient
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{ingredientName} collected!");
            BakingUI.Instance.AddIngredient(ingredientName); // Update the BakingUI with the collected ingredient
            Destroy(gameObject); // Remove the ingredient from the scene
        }
    }
}