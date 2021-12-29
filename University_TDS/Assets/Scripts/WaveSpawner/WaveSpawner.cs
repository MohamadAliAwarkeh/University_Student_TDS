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
    public GameObject enemyType04;
    public GameObject boss;

    [Header("References")]
    public Transform enemyParentObj;

    //Private Variables
    private int currentWave = 1;
    private float timeBetweenWaves;

    #region Unity Functions
    private void Start() => timeBetweenWaves = waveCountdown;

    private void Update()
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
        if (i == 1)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
        }
        if (i == 2)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
            SpawnEnemy(enemyType02, spawnPointSeven);
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