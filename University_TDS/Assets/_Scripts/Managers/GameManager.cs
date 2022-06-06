using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("States")]
    public GameState gameState;
    public GameMode gameMode;

    [Header("Timer Settings")]
    public float timeBetweenWaves;
    [Space(5)]
    public TextMeshPro timerText;
    public GameObject endlessTimerText;

    [Header("References To Panels")]
    public GameObject mainMenuPanel;
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject endlessPanel;

    [Header("References To Gamemodes")]
    public GameObject waveMode;
    public GameObject endlessMode;

    //Private Variables
    private float timer;
    private bool pauseMenuActive = false;

    private void Start() => timer = timeBetweenWaves;

    private void Update()
    {
        PauseMenu();

        //Handles game states
        switch (gameState)
        {
            case GameState.GameWin:
                DisplayWinPanel();
                Reset();
                break;

            case GameState.GameLoss:
                DisplayLosePanel();
                Reset();
                break;

            case GameState.EndlessGameOver:
                DisplayEndlessPanel();
                Reset();
                break;
        }

        //Handles game modes
        switch (gameMode)
        {
            //Set to this state from the MenuButton.cs
            case GameMode.MainGame:
                GameCountdown();
                break;

            //Set to this state from the MenuButton.cs
            case GameMode.EndlessMode:
                GameCountdown();

                //Endable endless mode text
                endlessTimerText.SetActive(true);
                break;
        }     
    }

    private void GameCountdown()
    {
        if (gameState == GameState.MainMenu)
        {
            //Set text to display countdown
            timerText.gameObject.SetActive(true);
            timerText.SetText(timer.ToString("#"));
            //Counts down
            timer -= Time.deltaTime;
            //If timer reaches 0, then...
            if (timer <= 0)
            {
                //Disable text
                timerText.gameObject.SetActive(false);
                //Change state
                gameState = GameState.InProgress;
            }
        }
        
    }

    #region Panel Functions
    private void DisplayLosePanel() => losePanel.SetActive(true);

    private void DisplayWinPanel() => winPanel.SetActive(true);

    private void DisplayEndlessPanel() => endlessPanel.SetActive(true);
    #endregion

    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseMenuActive = !pauseMenuActive;

        if (Input.GetKeyDown(KeyCode.Space) && gameState == GameState.Pause)
            SceneManager.LoadScene(0);

        if (pauseMenuActive && gameState == GameState.InProgress)
        {
            gameState = GameState.Pause;
            pausePanel.SetActive(true);
        }
        if (!pauseMenuActive && gameState == GameState.Pause)
        {
            gameState = GameState.InProgress;
            pausePanel.SetActive(false);
        }
    }

    private void Reset()
    {
        //If any input is detected, reset
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(0);

        //Change gamemode
        gameMode = GameMode.None;
    }

}

public enum GameState
{
    MainMenu,
    InProgress,
    GameWin,
    GameLoss,
    EndlessGameOver,
    Pause
}

public enum GameMode
{
    None,
    MainGame,
    EndlessMode
}
