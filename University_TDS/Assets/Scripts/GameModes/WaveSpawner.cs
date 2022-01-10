using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaveSpawner : MonoBehaviour
{
    [Header("Wave State")]
    public WaveState waveState;

    [Header("General Wave Information")]
    public int currentAmount;
    public int requiredAmount;
    [Space(5)]
    public float waveCountdown;

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

    [Header("Enemy Types")]
    public GameObject enemyType01;
    public GameObject enemyType02;
    public GameObject enemyType03;

    [Header("References")]
    public Transform enemyParentObj;

    //Private Variables
    private int currentWave = 0;
    private float timeBetweenWaves;
    private GameManager gameManager;

    #region Unity Functions
    private void Start()
    {
        //Set timer
        timeBetweenWaves = waveCountdown;
        //Get reference
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        //Call based on game state
        if (gameManager.gameState == GameState.InProgress)
        {
            //Switch statement based on current wave settings
            switch (waveState)
            {
                case WaveState.Starting:
                    BeginWave(currentWave);
                    break;

                case WaveState.InProgress:
                    GoalReached();
                    break;

                case WaveState.Completed:
                    TimeBetweenWaves();
                    break;
            }
        }
    }
    #endregion

    #region Completed Wave Functions
    private void TimeBetweenWaves()
    {
        //Countdown
        timeBetweenWaves -= Time.deltaTime;

        if (timeBetweenWaves <= 0)
        {
            //Reset timer
            timeBetweenWaves = waveCountdown;
            //Increment
            currentWave++;
            //Change state
            waveState = WaveState.Starting;
        }
    }

    private bool GoalReached()
    {
        if (currentAmount >= requiredAmount)
        {
            //Reset current amount
            currentAmount = 0;
            //Change state
            waveState = WaveState.Completed;
            //return
            return true;
        }

        //return
        return false;
    }
    #endregion

    #region Wave / Enemy Functions
    private void BeginWave(int i)
    {
        //Spawn wave based on currentWave 
        if (i == 0)
        {
            SpawnEnemy(enemyType01, spawnPointBoss);
        }
        if (i == 1)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
        }
        if (i == 2)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
            SpawnEnemy(enemyType01, spawnPointSeven);
        }
        if (i == 3)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
            SpawnEnemy(enemyType01, spawnPointFive);
            SpawnEnemy(enemyType01, spawnPointNine);
        }
        if (i == 4)
        {
            SpawnEnemy(enemyType02, spawnPointBoss);
        }
        if (i == 5)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType02, spawnPointFour);
        }
        if (i == 6)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
            SpawnEnemy(enemyType02, spawnPointSeven);
        }
        if (i == 7)
        {
            SpawnEnemy(enemyType03, spawnPointBoss);
        }
        if (i == 8)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
            SpawnEnemy(enemyType03, spawnPointSeven);
        }
        if (i == 9)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
            SpawnEnemy(enemyType03, spawnPointFive);
            SpawnEnemy(enemyType03, spawnPointNine);
        }
        if (i == 10)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
            SpawnEnemy(enemyType02, spawnPointSeven);
            SpawnEnemy(enemyType03, spawnPointFive);
            SpawnEnemy(enemyType03, spawnPointNine);
        }
        if (i == 11)
        {
            //A bit of a cheat, but when you complete all waves
            //increment one last time and change the game state
            gameManager.gameState = GameState.GameWin;
        }

        //Set required amount based on the number of enemies spawned
        requiredAmount = enemyParentObj.childCount;
        //Change state
        waveState = WaveState.InProgress;
    }

    // Simple function that takes two parameters for ease of creating enemies
    private void SpawnEnemy(GameObject enemy, Transform transform)
    {
        //Create the enemy
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        //Parent enemy to reference
        newEnemy.transform.parent = enemyParentObj.transform;
    }
    #endregion
}

public enum WaveState
{
    Starting,
    InProgress,
    Completed
}