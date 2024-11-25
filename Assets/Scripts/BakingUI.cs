using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakingUI : MonoBehaviour
{
    public static BakingUI Instance;

    public GameObject uiPanel; // The UI panel
    public GameObject[] ingredientIcons; // Icons for Flour, Sugar, Butter
    public GameObject crumblePlatformIcon; // Crumble Platform icon
    public Button createButton; // Create button

    private bool hasFlour = false;
    private bool hasSugar = false;
    private bool hasButter = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenUI()
    {
        uiPanel.SetActive(true); 


        ingredientIcons[0].SetActive(hasFlour); 
        ingredientIcons[1].SetActive(hasSugar); 
        ingredientIcons[2].SetActive(hasButter); 
        crumblePlatformIcon.SetActive(hasFlour && hasSugar && hasButter);

        createButton.interactable = hasFlour && hasSugar && hasButter;
    }

    public void CloseUI()
    {
        uiPanel.SetActive(false); 
    }

    public void AddIngredient(string ingredientName)
    {
        if (ingredientName == "Flour") hasFlour = true;
        else if (ingredientName == "Sugar") hasSugar = true;
        else if (ingredientName == "Butter") hasButter = true;
    }

    public void CreateCrumblePlatform()
    {
        if (hasFlour && hasSugar && hasButter)
        {
            PlatformPlacement.Instance.StartPlacingPlatform();

            hasFlour = hasSugar = hasButter = false;
            CloseUI(); 
        }
        else
        {
            Debug.LogWarning("Cannot create platform, missing ingredients.");
        }
    }
}