using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourblindManager : MonoBehaviour
{
    [Header("Select Buttons")]
    public SpriteRenderer defaultColours;
    public SpriteRenderer deuteranopiaColours;
    public SpriteRenderer protanopiaColours;
    public SpriteRenderer triantopiaColours;

    [Header("Default Colours")]
    public Color defaultRare;
    public Color defaultLegendary;
    public Color defaultOverheated;

    [Header("Deuteranopia Colours")]
    public Color deuteranopiaRare;
    public Color deuteranopiaLegendary;
    public Color deuteranopiaOverheated;

    [Header("Protanopia Colours")]
    public Color protanopiaRare;
    public Color protanopiaLegendary;
    public Color protanopiaOverheated;

    [Header("Tritanopia Colours")]
    public Color tritanopiaRare;
    public Color trianopiaLegendary;
    public Color tritanopiaOverheated;

    [Header("Prefab References")]
    public GameObject enemyType01Rare;
    public GameObject enemyType02Rare;
    public GameObject enemyType03Rare;
    public GameObject bossRare;
    [Space(10)]
    public GameObject enemyType01Legendary;
    public GameObject enemyType02Legendary;
    public GameObject enemyType03Legendary;
    public GameObject bossLegendary;
    [Space(10)]
    public GameObject enemyType01Overheated;
    public GameObject enemyType02Overheated;
    public GameObject enemyType03Overheated;
    public GameObject bossOverheated;

    //Private variables
    private ColourblindMode colourblindMode;

    private void Update()
    {
        switch (colourblindMode)
        {
            case ColourblindMode.Default:
                DefaultMode();
                break;

            case ColourblindMode.Deuteranopia:
                DeuteranopiaMode();
                break;

            case ColourblindMode.Protanopia:
                ProtanopiaMode();
                break;

            case ColourblindMode.Tritanopia:
                TritanopiaMode();
                break;
        }
    }

    #region Colourblind Functions
    private void DefaultMode()
    {
        //Handle Rare Colours

        //Handle Legendary Colours

        //Handle Overheated Colours
    }

    private void DeuteranopiaMode()
    {
        //Handle Rare Colours

        //Handle Legendary Colours

        //Handle Overheated Colours
    }

    private void ProtanopiaMode()
    {
        //Handle Rare Colours

        //Handle Legendary Colours

        //Handle Overheated Colours
    }

    private void TritanopiaMode()
    {
        //Handle Rare Colours

        //Handle Legendary Colours

        //Handle Overheated Colours
    }
    #endregion
}

public enum ColourblindMode
{
    Default,
    Deuteranopia,
    Protanopia,
    Tritanopia
}
