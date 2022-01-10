using UnityEngine;
using TMPro;

public class SelectButton : MonoBehaviour
{
    [Header("Text")]
    public TextMeshPro text;

    [Header("Button Colours")]
    public Color baseColour;
    public Color highlightedColour;

    [Header("Button Font Size")]
    public float originalScale;
    public float highlightedScale;

    [Header("Colourblind Mode")]
    public ColourblindMode colourblindMode;

    //Private Variables
    private SpriteRenderer mouseCol;
    private SpriteRenderer thisCol;
    private ColourblindManager colourblindManager;

    private void Start()
    {
        //Get colliders
        mouseCol = GameObject.Find("MouseInteractionObj").GetComponent<SpriteRenderer>();
        thisCol = this.GetComponentInChildren<SpriteRenderer>();

        //Get reference
        colourblindManager = GameObject.Find("GameManager").GetComponent<ColourblindManager>();
    }

    private void Update()
    {
        //If the mouse is over the button
        if (mouseCol.bounds.Intersects(thisCol.bounds))
            MouseOver();
        //If there is a mouse press
        if (mouseCol.bounds.Intersects(thisCol.bounds) && Input.GetMouseButtonDown(0))
        {
            //Change text
            text.SetText("Selected");
            //Change colourblind mode
            colourblindManager.colourblindMode = colourblindMode;
        }
        //If the mouse exists the button
        if (!mouseCol.bounds.Intersects(thisCol.bounds))
            MouseExit();

        //If the current state isnt what is expected, change text
        if (colourblindManager.colourblindMode != colourblindMode)
            text.SetText("Select");
    }

    #region Mouse Functions
    private void MouseOver()
    {
        //Change colour
        text.color = highlightedColour;
        //Increase scale
        text.fontSize = highlightedScale;
    }

    private void MouseExit()
    {
        //Set colour back to original
        text.color = baseColour;
        //Set scale back to original
        text.fontSize = originalScale;
    }
    #endregion
}
