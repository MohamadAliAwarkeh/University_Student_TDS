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

    private void Start() => gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    private void Update()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            if (gameManager.gameMode == GameMode.None)
            {
                //Do nothing
            }
            else if (gameManager.gameMode == GameMode.EndlessMode)
            {
                //Call functions
                GameTimer();
                EndGamePanelDisplay();
            }
        }
    }

    private void GameTimer()
    {
        //Timer increasing 
        onGoingGameTimer += Time.deltaTime;
        //Display the timer in minutes and seconds
        float minutes = Mathf.FloorToInt(onGoingGameTimer / 60);
        float seconds = Mathf.FloorToInt(onGoingGameTimer % 60);
        //Set text to visualise time
        onGoingGameText.SetText("{0:00}:{1:00}", minutes, seconds);
    }

    private void EndGamePanelDisplay()
    {
        //Set texts
        suriviedForText.SetText("You Survived For: " + onGoingGameText.text);
        enemiesKilledText.SetText("Enemies Killed: " + enemiesDestroyed.ToString());
    }
}
