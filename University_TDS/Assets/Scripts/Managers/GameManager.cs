using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game State")]
    public GameState gameState;

    [Header("Timer Settings")]
    public float timeBetweenWaves;
    [Space(5)]
    public TextMeshPro timerText;

    [Header("References To Panels")]
    public GameObject mainMenuPanel;
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("References To Gamemodes")]
    public GameObject waveMode;
    public GameObject endlessMode;

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

                break;

            //Set to this state from the MenuButton.cs
            case GameState.MainGame:
                GameCountdown();
                break;

            //Set to this state from the MenuButton.cs
            case GameState.EndlessMode:
                GameCountdown();
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

    private void GameCountdown()
    {
        //Set text to display countdown
        timerText.gameObject.SetActive(true);
        timerText.SetText(timer.ToString("#"));
        //Counts down
        timer -= Time.deltaTime;
        //If timer reaches 0, then...
        if (timer <= 0)
        {
            //Reset timer
            timer = timeBetweenWaves;
            //Disable text
            timerText.gameObject.SetActive(false);
            //Change state
            gameState = GameState.InProgress;
        }
    }

    private void Reset()
    {
        //If any input is detected, reset
        if (Input.anyKeyDown)
            SceneManager.LoadScene(0);
    }

    #region Panel Functions
    private void DisplayLosePanel() => losePanel.SetActive(true);

    private void DisplayWinPanel() => winPanel.SetActive(true);
    #endregion

}

public enum GameState
{
    MainMenu,
    MainGame,
    EndlessMode,
    InProgress,
    GameWin,
    GameLoss
}
