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
    [Space(10)]
    public EndlessEnemyType rare_EnemyType01;
    public EndlessEnemyType rare_EnemyType02;
    public EndlessEnemyType rare_EnemyType03;
    [Space(10)]
    public EndlessEnemyType legendary_EnemyType01;
    public EndlessEnemyType legendary_EnemyType02;
    public EndlessEnemyType legendary_EnemyType03;
    [Space(10)]
    public EndlessEnemyType overheated_EnemyType01;
    public EndlessEnemyType overheated_EnemyType02;
    public EndlessEnemyType overheated_EnemyType03;

    [Header("Tier Weights")]
    public int baseTierWeight;
    public int rareTierWeight;
    public int legendaryTierWeight;
    public int overheatedTierWeight;

    [Header("References")]
    public Transform enemyParentObj;
    public EndlessScoreboard endlessScoreboard;

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
            CalculateEnemyTierSpawnChance();
            EnemyWeightChangeOvertime();
        }
    }

    /// <summary>
    /// This function handles the randomisation of the different tiers of enemies that can be spawned.
    /// We create a more 'organic' feeling of progressive difficulty increase with a weight system!
    /// </summary>
    private void CalculateEnemyTierSpawnChance()
    {
        //A local variable 
        int maxTierWeight = baseTierWeight + rareTierWeight
            + legendaryTierWeight + overheatedTierWeight;
        //Then randomly pick a number between 1 and max tier weight
        int randomValue = Random.Range(1, maxTierWeight);

        //Then, based on the random number picked, it will spawn an enemy of the respective tier
        if (randomValue <= baseTierWeight)
            CalculateBaseEnemySpawnChance();
        if (randomValue >= baseTierWeight && randomValue <= rareTierWeight)
            CalculateRareEnemySpawnChance();
        if (randomValue >= rareTierWeight && randomValue <= legendaryTierWeight)
            CalculateLegendaryEnemySpawnChance();
        if (randomValue >= legendaryTierWeight && randomValue <= overheatedTierWeight)
            CalculateOverheatedEnemySpawnChance();
    }

    /// <summary>
    ///This function simply calls each time there is an enemy spawned and changes the chances of enemies spawning
    /// </summary>
    private void EnemyWeightChangeOvertime()
    {
        if (endlessScoreboard.onGoingGameTimer >= 60)
        {
            //Increment the weights
            baseTierWeight -= 5;
            rareTierWeight += 5;
        } 
        if (endlessScoreboard.onGoingGameTimer >= 180)
        {
            //Increment the weights
            baseTierWeight -= 5;
            rareTierWeight -= 5;
            legendaryTierWeight += 5;
        }
        if (endlessScoreboard.onGoingGameTimer >= 300)
        {
            //Increment the weights
            rareTierWeight -= 5;
            legendaryTierWeight -= 5;
            overheatedTierWeight += 5;
        }
        if (endlessScoreboard.onGoingGameTimer >= 420)
            overheatedTierWeight = 100;


        //If base weight reaches 0, stop, and so on...
        if (baseTierWeight <= 0) baseTierWeight = 0;
        if (rareTierWeight <= 0) rareTierWeight = 0;
        if (legendaryTierWeight <= 0) legendaryTierWeight = 0;
        if (overheatedTierWeight <= 0) overheatedTierWeight = 0;

        //We do the same if it reaches 100
        if (baseTierWeight > 100) baseTierWeight = 100;
        if (rareTierWeight > 100) rareTierWeight = 100;
        if (legendaryTierWeight > 100) legendaryTierWeight = 100;
        if (overheatedTierWeight > 100) overheatedTierWeight = 100;
    }

    #region Enemy Functions
    /// <summary>
    /// This is a summary for this entire region of functions. Here I have multiple functions
    /// handling all spawn chances for all enemy tiers From Base => Overheated.
    /// </summary>
    private void CalculateBaseEnemySpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = base_EnemyType03.maxSpawnWeight;
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
    }

    private void CalculateRareEnemySpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = rare_EnemyType03.maxSpawnWeight;
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
    }

    private void CalculateLegendaryEnemySpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = legendary_EnemyType03.maxSpawnWeight;
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
    }

    private void CalculateOverheatedEnemySpawnChance()
    {
        //A local variable to contain all enemy weights
        int enemyWeights = overheated_EnemyType03.maxSpawnWeight;
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

        if (randomValue == 0)
        {
            spawnPoint = spawnPointOne;
            return spawnPoint;
        }
        if (randomValue == 1)
        {
            spawnPoint = spawnPointTwo;
            return spawnPoint;
        }
        if (randomValue == 2)
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
            spawnPoint = spawnPointThree;
            return spawnPoint;
        }
        if (randomValue == 5)
        {
            spawnPoint = spawnPointFour;
            return spawnPoint;
        }
        if (randomValue == 6)
        {
            spawnPoint = spawnPointFive;
            return spawnPoint;
        }
        if (randomValue == 7)
        {
            spawnPoint = spawnPointSix;
            return spawnPoint;
        }
        if (randomValue == 8)
        {
            spawnPoint = spawnPointSeven;
            return spawnPoint;
        }
        if (randomValue == 9)
        {
            spawnPoint = spawnPointEight;
            return spawnPoint;
        }
        if (randomValue == 10)
        {
            spawnPoint = spawnPointNine;
            return spawnPoint;
        }
        if (randomValue == 11)
        {
            spawnPoint = spawnPointBoss;
            return spawnPoint;
        }

        return null;
    }
    #endregion
}
