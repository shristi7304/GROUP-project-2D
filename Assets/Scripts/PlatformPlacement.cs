using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlacement : MonoBehaviour

{
    public static PlatformPlacement Instance;
    public GameObject platformPrefab; 

    private GameObject currentPlatform;

    private void Awake()
    {
        Instance = this;
    }

    public void StartPlacingPlatform()
    {
        currentPlatform = Instantiate(platformPrefab);
        currentPlatform.GetComponent<Collider2D>().enabled = false; 
    }

    private void Update()
    {
        if (currentPlatform != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPlatform.transform.position = mousePosition;

            if (Input.GetMouseButtonDown(0)) 
            {
                currentPlatform.GetComponent<Collider2D>().enabled = true; 
                currentPlatform = null; 
            }
        }
    }
}