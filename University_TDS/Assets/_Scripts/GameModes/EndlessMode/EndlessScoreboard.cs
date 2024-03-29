using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessScoreboard : MonoBehaviour
{
    [Header("Text")]
    public TextMeshPro onGoingGameText;
    [Space(5)]
    public TextMeshPro suriviedForText;
    public TextMeshPro enemiesKilledText;

    [Header("References")]
    public GameManager gameManager;

    //Private variable
    [HideInInspector] public float onGoingGameTimer;
    [HideInInspector] public int enemiesDestroyed;

    private string currentTimer;

    private void Start() => gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    private void Update()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            //Call functions
            EndGamePanelDisplay();
            GameTimer();
        }
    }

    private void GameTimer()
    {
        //Timer increasing 
        onGoingGameTimer += Time.deltaTime;
        //Display the timer in minutes and seconds
        float minutes = Mathf.FloorToInt(onGoingGameTimer / 60);
        float seconds = Mathf.FloorToInt(onGoingGameTimer - minutes * 60);
        //Set text to visualise time
        currentTimer = string.Format("{0:0}:{1:00}", minutes, seconds);
        onGoingGameText.SetText(currentTimer);
    }

    private void EndGamePanelDisplay()
    {
        //Set texts
        suriviedForText.SetText("You Survived For: " + currentTimer);
        enemiesKilledText.SetText("Enemies Killed: " + enemiesDestroyed.ToString());
    }
}
