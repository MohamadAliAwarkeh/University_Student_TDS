using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game State")]
    public GameState gameState;

    [Header("General Settings")]
    public float timeBetweenWaves;

    [Header("References")]
    public GameObject mainMenuPanel;
    public GameObject winPanel;
    public GameObject losePanel;

    //Private Variables
    private float timer;

    private void Start()
    {
        timer = timeBetweenWaves;
    }

    void Update()
    {
        //Handles game states
        switch (gameState)
        {
            case GameState.MainMenu:
                DisplayMainMenu();
                //This is also where all resets that need to happen will
                break;

            case GameState.InGame:
                GameStartCountdown();
                break;

            case GameState.InProgress:
                //This is for all the other classes to switch to this game state
                break;

            case GameState.GameWin:
                DisplayWinPanel();
                Reset();
                break;

            case GameState.GameLoss:
                DisplayLosePanel();
                Reset();
                break;
        }
    }

    private void GameStartCountdown()
    {
        //Counts down
        timer -= Time.deltaTime;
        //If timer reaches 0, then...
        if (timer <= 0)
        {
            //Reset timer
            timer = timeBetweenWaves;
            //Change state
            gameState = GameState.InProgress;
        }
    }

    private void Reset()
    {
        //If any input is detected, reset
        if (Input.anyKeyDown)
            gameState = GameState.MainMenu;
    }

    #region Panel Functions
    private void DisplayMainMenu()
    {
        mainMenuPanel.SetActive(true);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    private void DisplayLosePanel() => losePanel.SetActive(true);

    private void DisplayWinPanel() => winPanel.SetActive(true);
    #endregion

}

public enum GameState
{
    MainMenu,
    InGame,
    InProgress,
    GameWin,
    GameLoss
}
