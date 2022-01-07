using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessScoreboard : MonoBehaviour
{
    [Header("Timer")]
    public TextMeshPro onGoingGameText;

    //Private variable
    private float onGoingGameTimer;

    private void Update()
    {
        //Call functions
        GameTimer();
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
}
