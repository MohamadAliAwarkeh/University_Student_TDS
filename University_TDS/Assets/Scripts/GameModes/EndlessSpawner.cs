using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessSpawner : MonoBehaviour
{
    [Header("General Settings")]
    public float spawnTimer;
    [Space(10)]
    public float onGoingGameTimer;
    public TextMeshPro onGoingGameText;

    [Header("Spawnpoints")]
    public Transform spawnPointOne;
    public Transform spawnPointTwo;
    public Transform spawnPointThree;
    public Transform spawnPointFour;
    public Transform spawnPointFive;
    public Transform spawnPointSix;
    public Transform spawnPointSeven;
    public Transform spawnPointEight;
    public Transform spawnPointNine;
    public Transform spawnPointBoss;

    [Header("Enemy Settings")]
    public GameObject enemyType01;
    public int spawnWeightMin01;
    public int spawnWeightMax01;
    [Space(10)]
    public GameObject enemyType02;
    public int spawnWeightMin02;
    public int spawnWeightMax02;
    [Space(10)]
    public GameObject enemyType03;
    public int spawnWeightMin03;
    public int spawnWeightMax03;
    [Space(10)]
    public GameObject boss;
    public int spawnWeightMinBoss;
    public int spawnWeightMaxBoss;

    [Header("References")]
    public Transform enemyParentObj;

    //Private Variables
    private float timer;
    private int spawnpointLength = 10;

    private void Start()
    {
        //Setting timer
        timer = spawnTimer;
    }

    private void FixedUpdate()
    {
        //Call functions
        SpawnEnemy();
        GameTimer();
    }

    #region Enemy Functions
    private void SpawnEnemy()
    {
        //countdown
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Reset timer
            timer = spawnTimer;
            //Call function
            CalculateSpawnChance();
        }
    }

    private void CalculateSpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = spawnWeightMaxBoss;
        //Then randomly pick a number between 0 and the max enemy weight
        int randomValue = Random.Range(0, enemyWeights);

        //Based on the selected weight, we will spawn the repsective enemey
        if (randomValue >= spawnWeightMin01 && randomValue <= spawnWeightMax01)
            Instantiate(enemyType01, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);

        if (randomValue >= spawnWeightMin02 && randomValue <= spawnWeightMax02)
            Instantiate(enemyType02, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);

        if (randomValue >= spawnWeightMin03 && randomValue <= spawnWeightMax03)
            Instantiate(enemyType03, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);

        if (randomValue >= spawnWeightMinBoss && randomValue <= spawnWeightMaxBoss)
            Instantiate(boss, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
    }

    /// <summary>
    /// A bit of a long winded one, but this is a custom function that returns a value.
    /// In this case, that is a Transform. But additionally, it also takes in a parameter
    /// which is an int. 
    /// 
    /// The point of this is to assit in randomising the spawn position of the enemies created. 
    /// Firstly we locally create a Transform variable called spawnpoint, and from there, we return
    /// the spawnpoint VALUE once certain parameters are met.
    /// 
    /// If none of these parameters are met, then we simply return null as we do not want ANY to come back.
    /// </summary>
    private Transform RandomSpawnPoint(int randomValue)
    {
        Transform spawnPoint;

        if (randomValue == 1)
        {
            spawnPoint = spawnPointOne;
            return spawnPoint;
        }
        if (randomValue == 2)
        {
            spawnPoint = spawnPointTwo;
            return spawnPoint;
        }
        if (randomValue == 3)
        {
            spawnPoint = spawnPointThree;
            return spawnPoint;
        }
        if (randomValue == 3)
        {
            spawnPoint = spawnPointThree;
            return spawnPoint;
        }
        if (randomValue == 3)
        {
            spawnPoint = spawnPointThree;
            return spawnPoint;
        }
        if (randomValue == 4)
        {
            spawnPoint = spawnPointFour;
            return spawnPoint;
        }
        if (randomValue == 5)
        {
            spawnPoint = spawnPointFive;
            return spawnPoint;
        }
        if (randomValue == 6)
        {
            spawnPoint = spawnPointSix;
            return spawnPoint;
        }
        if (randomValue == 7)
        {
            spawnPoint = spawnPointSeven;
            return spawnPoint;
        }
        if (randomValue == 8)
        {
            spawnPoint = spawnPointEight;
            return spawnPoint;
        }
        if (randomValue == 9)
        {
            spawnPoint = spawnPointNine;
            return spawnPoint;
        }
        if (randomValue == 10)
        {
            spawnPoint = spawnPointBoss;
            return spawnPoint;
        }

        return null;
    }
    #endregion

    #region Extras Functions
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
    #endregion
}
