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
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject endlessPanel;

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
            case GameState.GameWin:
                DisplayWinPanel();
                Reset();

                //Change gamemode
                gameMode = GameMode.None;
                break;

            case GameState.GameLoss:
                DisplayLosePanel();
                Reset();

                //Change gamemode
                gameMode = GameMode.None;
                break;

            case GameState.EndlessGameOver:
                DisplayEndlessPanel();
                Reset();

                //Change gamemode
                gameMode = GameMode.None;
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

    private void Reset()
    {
        //If any input is detected, reset
        if (Input.anyKeyDown)
            SceneManager.LoadScene(0);
    }

    #region Panel Functions
    private void DisplayLosePanel() => losePanel.SetActive(true);

    private void DisplayWinPanel() => winPanel.SetActive(true);

    private void DisplayEndlessPanel() => endlessPanel.SetActive(true);
    #endregion

}

public enum GameState
{
    MainMenu,
    InProgress,
    GameWin,
    GameLoss,
    EndlessGameOver
}

public enum GameMode
{
    None,
    MainGame,
    EndlessMode
}
