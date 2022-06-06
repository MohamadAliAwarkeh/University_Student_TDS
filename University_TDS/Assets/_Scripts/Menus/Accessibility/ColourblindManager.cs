using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColourblindManager : MonoBehaviour
{
    [Header("General Settings")]
    public ColourblindMode colourblindMode;

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
}

public enum ColourblindMode
{
    Default,
    Deuteranopia,
    Protanopia,
    Tritanopia
}
