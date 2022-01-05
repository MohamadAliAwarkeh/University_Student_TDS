using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuButton : MonoBehaviour
{
    [Header("General Button Settings")]
    public TextMeshPro text;
    public ButtonTypes buttonType;

    [Header("Button Colours")]
    public Color baseColour;
    public Color highlightedColour;

    [Header("Button Font Size")]
    public float originalScale;
    public float highlightedScale;

    [Header("References")]
    public GameManager gameManager;
    [Space(5)]
    public GameObject mainMenu;
    public GameObject controlsPanel;

    //Private Variables
    private SpriteRenderer mouseCol;
    private SpriteRenderer thisCol;

    private void Start()
    {
        mouseCol = GameObject.Find("MouseInteractionObj").GetComponent<SpriteRenderer>();
        thisCol = this.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        //If the mouse is over the button
        if (mouseCol.bounds.Intersects(thisCol.bounds))
            MouseOver();
        //If the mouse presses the button
        if (mouseCol.bounds.Intersects(thisCol.bounds) && Input.GetMouseButtonDown(0))
        {
            //Based on the button type, a certain function will then be called
            switch (buttonType)
            {
                case ButtonTypes.StartGame:
                    StartGame();
                    break;

                case ButtonTypes.EndlessMode:
                    StartEndlessMode();
                    break;

                case ButtonTypes.Controls:
                    DisplayControlsPanel();
                    break;

                case ButtonTypes.MainMenu:
                    DisplayMainMenu();
                    break;

                case ButtonTypes.Quit:
                    QuitGame();
                    break;
            }

        }
        //If the mouse exists the button
        if (!mouseCol.bounds.Intersects(thisCol.bounds))
            MouseExit();
    }

    #region Functions for enums
    private void StartGame()
    {
        //Change state
        gameManager.gameState = GameState.MainGame;
        //Disable main menu
        mainMenu.SetActive(false);
        //Setting gamemode
        gameManager.waveMode.SetActive(true);
        gameManager.endlessMode.SetActive(false);
    }

    private void StartEndlessMode()
    {
        //Change state
        gameManager.gameState = GameState.EndlessMode;
        //Disable main menu
        mainMenu.SetActive(false);
        //Setting gamemode
        gameManager.endlessMode.SetActive(true);
        gameManager.waveMode.SetActive(false);
    }

    private void DisplayControlsPanel()
    {
        //Display controls panel
        controlsPanel.SetActive(true);
        //Disable main menu
        mainMenu.SetActive(false);
    }

    private void DisplayMainMenu()
    {
        //Display main menu
        mainMenu.SetActive(true);
        //Disable controls panel
        controlsPanel.SetActive(false);
    }

    private void QuitGame()
    {
        //Quits the game
        Application.Quit();
    }
    #endregion

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

public enum ButtonTypes
{
    StartGame,
    EndlessMode,
    Controls,
    MainMenu,
    Quit
}
