using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RarityBorderColour : MonoBehaviour
{
    [Header("Rarity Type")]
    public EnemyRarity rarity;

    //Private variables
    private ColourblindManager colourblindManager;
    private SpriteRenderer mySR;

    private void Start()
    {
        //Get reference
        colourblindManager = GameObject.Find("Accessibility").GetComponent<ColourblindManager>();
        mySR = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (rarity)
        {
            case EnemyRarity.Rare:
                HandleRareType();
                break;

            case EnemyRarity.Legendary:
                HandleLegendaryType();
                break;

            case EnemyRarity.Overheated:
                HandleOverheatedType();
                break;
        }
    }

    #region Rarity Functions
    private void HandleRareType()
    {
        switch (colourblindManager.colourblindMode)
        {
            case ColourblindMode.Default:
                mySR.color = colourblindManager.defaultRare;
                break;

            case ColourblindMode.Deuteranopia:
                mySR.color = colourblindManager.deuteranopiaRare;
                break;

            case ColourblindMode.Protanopia:
                mySR.color = colourblindManager.protanopiaRare;
                break;

            case ColourblindMode.Tritanopia:
                mySR.color = colourblindManager.tritanopiaRare;
                break;
        }
    }

    private void HandleLegendaryType()
    {
        switch (colourblindManager.colourblindMode)
        {
            case ColourblindMode.Default:
                mySR.color = colourblindManager.defaultLegendary;
                break;

            case ColourblindMode.Deuteranopia:
                mySR.color = colourblindManager.deuteranopiaLegendary;
                break;

            case ColourblindMode.Protanopia:
                mySR.color = colourblindManager.protanopiaLegendary;
                break;

            case ColourblindMode.Tritanopia:
                mySR.color = colourblindManager.trianopiaLegendary;
                break;
        }
    }

    private void HandleOverheatedType()
    {
        switch (colourblindManager.colourblindMode)
        {
            case ColourblindMode.Default:
                mySR.color = colourblindManager.defaultOverheated;
                break;

            case ColourblindMode.Deuteranopia:
                mySR.color = colourblindManager.deuteranopiaOverheated;
                break;

            case ColourblindMode.Protanopia:
                mySR.color = colourblindManager.protanopiaOverheated;
                break;

            case ColourblindMode.Tritanopia:
                mySR.color = colourblindManager.tritanopiaOverheated;
                break;
        }
    }
    #endregion
}

public enum EnemyRarity
{
    Rare,
    Legendary,
    Overheated
}
