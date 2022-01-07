using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Enemy References")]
    public EndlessEnemyType base_EnemyType01;
    public EndlessEnemyType base_EnemyType02;
    public EndlessEnemyType base_EnemyType03;
    public EndlessEnemyType base_Boss;
    [Space(10)]
    public EndlessEnemyType rare_EnemyType01;
    public EndlessEnemyType rare_EnemyType02;
    public EndlessEnemyType rare_EnemyType03;
    public EndlessEnemyType rare_Boss;
    [Space(10)]
    public EndlessEnemyType legendary_EnemyType01;
    public EndlessEnemyType legendary_EnemyType02;
    public EndlessEnemyType legendary_EnemyType03;
    public EndlessEnemyType legendary_Boss;
    [Space(10)]
    public EndlessEnemyType overheated_EnemyType01;
    public EndlessEnemyType overheated_EnemyType02;
    public EndlessEnemyType overheated_EnemyType03;
    public EndlessEnemyType overheated_Boss;

    [Header("Scoreboard")]
    public int enemiesDestroyed;

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

    private void FixedUpdate() => SpawnEnemy();

    /// <summary>
    /// This function is the TOP of the hierarchy! This is where all the enemies  actually spawn
    /// </summary>
    private void SpawnEnemy()
    {
        //countdown
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Reset timer
            timer = spawnTimer;
            //Call function

        }
    }

    #region Enemy Functions
    /// <summary>
    /// This is a summary for this entire region of functions. Here I have multiple functions
    /// handling all spawn chances for all enemy tiers From Base => Overheated.
    /// </summary>
    private void CalculateBaseEnemySpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = base_Boss.maxSpawnWeight;
        //Then randomly pick a number between 0 and the max enemy weight
        int randomValue = Random.Range(0, enemyWeights);

        //Local variables
        GameObject newEnemy;
        //Based on the selected weight
        if (randomValue >= base_EnemyType01.minSpawnWeight && randomValue <= base_EnemyType01.maxSpawnWeight)
        {
            //Spawn the enemy
            newEnemy = Instantiate(base_EnemyType01.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            //Assign parent
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= base_EnemyType02.minSpawnWeight && randomValue <= base_EnemyType02.maxSpawnWeight)
        {
            newEnemy = Instantiate(base_EnemyType02.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= base_EnemyType03.minSpawnWeight && randomValue <= base_EnemyType03.maxSpawnWeight)
        {
            newEnemy = Instantiate(base_EnemyType03.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= base_Boss.minSpawnWeight && randomValue <= base_Boss.maxSpawnWeight)
        {
            newEnemy = Instantiate(base_Boss.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }
    }

    private void CalculateRareEnemySpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = base_Boss.maxSpawnWeight;
        //Then randomly pick a number between 0 and the max enemy weight
        int randomValue = Random.Range(0, enemyWeights);

        //Local variables
        GameObject newEnemy;
        //Based on the selected weight
        if (randomValue >= rare_EnemyType01.minSpawnWeight && randomValue <= rare_EnemyType01.maxSpawnWeight)
        {
            //Spawn the enemy
            newEnemy = Instantiate(rare_EnemyType01.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            //Assign parent
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= rare_EnemyType02.minSpawnWeight && randomValue <= rare_EnemyType02.maxSpawnWeight)
        {
            newEnemy = Instantiate(rare_EnemyType02.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= rare_EnemyType03.minSpawnWeight && randomValue <= rare_EnemyType03.maxSpawnWeight)
        {
            newEnemy = Instantiate(rare_EnemyType03.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= rare_Boss.minSpawnWeight && randomValue <= rare_Boss.maxSpawnWeight)
        {
            newEnemy = Instantiate(rare_Boss.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }
    }

    private void CalculateLegendaryEnemySpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = base_Boss.maxSpawnWeight;
        //Then randomly pick a number between 0 and the max enemy weight
        int randomValue = Random.Range(0, enemyWeights);

        //Local variables
        GameObject newEnemy;
        //Based on the selected weight
        if (randomValue >= legendary_EnemyType01.minSpawnWeight && randomValue <= legendary_EnemyType01.maxSpawnWeight)
        {
            //Spawn the enemy
            newEnemy = Instantiate(legendary_EnemyType01.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            //Assign parent
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= legendary_EnemyType02.minSpawnWeight && randomValue <= legendary_EnemyType02.maxSpawnWeight)
        {
            newEnemy = Instantiate(legendary_EnemyType02.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= legendary_EnemyType03.minSpawnWeight && randomValue <= legendary_EnemyType03.maxSpawnWeight)
        {
            newEnemy = Instantiate(legendary_EnemyType03.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= legendary_Boss.minSpawnWeight && randomValue <= legendary_Boss.maxSpawnWeight)
        {
            newEnemy = Instantiate(legendary_Boss.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }
    }

    private void CalculateOverheatedEnemySpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = base_Boss.maxSpawnWeight;
        //Then randomly pick a number between 0 and the max enemy weight
        int randomValue = Random.Range(0, enemyWeights);

        //Local variables
        GameObject newEnemy;
        //Based on the selected weight
        if (randomValue >= overheated_EnemyType01.minSpawnWeight && randomValue <= overheated_EnemyType01.maxSpawnWeight)
        {
            //Spawn the enemy
            newEnemy = Instantiate(overheated_EnemyType01.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            //Assign parent
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= overheated_EnemyType02.minSpawnWeight && randomValue <= overheated_EnemyType02.maxSpawnWeight)
        {
            newEnemy = Instantiate(overheated_EnemyType02.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= overheated_EnemyType03.minSpawnWeight && randomValue <= overheated_EnemyType03.maxSpawnWeight)
        {
            newEnemy = Instantiate(overheated_EnemyType03.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }

        if (randomValue >= overheated_Boss.minSpawnWeight && randomValue <= overheated_Boss.maxSpawnWeight)
        {
            newEnemy = Instantiate(overheated_Boss.enemyPrefab, RandomSpawnPoint(Random.Range(0, spawnpointLength)).position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentObj.transform;
        }
    }
    #endregion

    #region Private Functions
    /// <summary>
    /// A bit of a long winded one, but this is a custom function that returns a value.
    /// In this case, that is a Transform. But additionally, it also takes in a parameter
    /// which is an int. 
    /// 
    /// The point of this is to assist in randomising the spawn position of the enemies created. 
    /// Firstly we create a localised Transform variable called spawnpoint, and from there, we return
    /// the spawnpoint VALUE once certain parameters are met.
    /// 
    /// If none of these parameters are met, then we simply return null as we do not want anything to come back.
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
}
