using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    [Header("General Settings")]
    public float spawnTimer;

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
    public float spawnWeight01;
    [Space(10)]
    public GameObject enemyType02;
    public float spawnWeight02;
    [Space(10)]
    public GameObject enemyType03;
    public float spawnWeight03;
    [Space(10)]
    public GameObject enemyType04;
    public float spawnWeight04;
    [Space(10)]
    public GameObject boss;
    public float spawnWeightBoss;

    [Header("References")]
    public Transform enemyParentObj;

    //Private Variables
    private int spawnChance = 100;
    private float timer;
    private int enemyLength = 5;
    private int spawnpointLength = 10;

    private void Start()
    {
        //Setting timer
        timer = spawnTimer;
    }

    //private void Update() => Instantiate(RandomEnemy(Random.Range(0, enemyLength)), RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);

    private void FixedUpdate() => StartCoroutine(SpawnEnemy());

    private IEnumerator SpawnEnemy()
    {
        //Return wait time
        yield return new WaitForSeconds(timer);
        //Call function
        CalculateSpawnChance();
        //Reset timer value
        timer = spawnTimer;
    }

    private void CalculateSpawnChance()
    {
        //Pick a number between 0 - 100
        int calculatedSpawnChance = Random.Range(0, 101);

        //If the random nuymber selected is less than the spawn chance,
        //then spawn the enemy (In this case, it ALWAYS will!)
        if (calculatedSpawnChance <= spawnChance)
        {
            //cached variable of the enemySpawns
            float enemyWeights = 0;
            //Add all the weights together
            enemyWeights += spawnWeight01 + spawnWeight02 + spawnWeight03 
                + spawnWeight04 + spawnWeightBoss;
            //Randomly pick a number between 0 and the enemy weights
            float randomValue = Random.Range(0, enemyWeights);

            //If the value is less than the spawn chance (which is 100%)
            if (randomValue <= spawnChance)
            {
                //Randomly Spawn enemy
                Instantiate(RandomEnemy(Random.Range(0, enemyLength)), RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
                //and then return
                return;
            }
            //If the value chosen is larger, then reduce the number
            randomValue -= spawnChance;
        }
    }

    private GameObject RandomEnemy(int randomValue)
    {
        GameObject enemy;

        if (randomValue == 1)
        {
            enemy = enemyType01;
            return enemy;
        }
        if (randomValue == 2)
        {
            enemy = enemyType02;
            return enemy;
        }
        if (randomValue == 3)
        {
            enemy = enemyType03;
            return enemy;
        }
        if (randomValue == 4)
        {
            enemy = enemyType04;
            return enemy;
        }
        if (randomValue == 5)
        {
            enemy = boss;
            return enemy;
        }

        return null;
    }

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

        return null;
    }
}
