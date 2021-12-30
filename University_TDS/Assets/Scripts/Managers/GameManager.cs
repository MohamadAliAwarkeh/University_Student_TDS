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
            case GameState.InGame:
                GameStartCountdown();
                break;

            case GameState.InProgress:
                break;

            case GameState.GameWin:
                DisplayWinPanel();
                break;

            case GameState.GameLoss:
                DisplayLosePanel();
                break;
        }
    }

    private void GameStartCountdown()
    {
        Debug.Log(timer);
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

    #region Panel Functions
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
