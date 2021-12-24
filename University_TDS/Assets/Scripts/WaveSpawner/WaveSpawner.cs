using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave State")]
    public WaveState waveState;

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

    //Private Variables
    private int currentWave = 1;

    private void Start() => HandleWaves(currentWave);

    private void Update()
    {
        switch (waveState)
        {
            case WaveState.Starting:

                break;

            case WaveState.InProgress:

                break;

            case WaveState.Completed:

                break;
        }
    }

    private void HandleWaves(int i)
    {
        if (i == 1)
        {
            SpawnEnemy(enemyType01, spawnPointOne);
            SpawnEnemy(enemyType01, spawnPointFour);
        }
    }

    // Simple function that takes two parameters for ease of creating enemies
    private void SpawnEnemy(GameObject enemy, Transform transform)
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}

public enum WaveState
{
    Starting,
    InProgress,
    Completed
}