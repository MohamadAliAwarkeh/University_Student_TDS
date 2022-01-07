using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int health;

    [Header("VFX")]
    public GameObject explosionVFX;

    [Header("References")]
    public EnemyController enemyController;

    //Private Variables
    private bool spawnedVFX;
    private float timer;
    [SerializeField]private WaveSpawner waveSpawner;
    [SerializeField]private EndlessSpawner endlessSpawner;
    private GameManager gameManager;

    private void Start()
    {
        //Getting all the references
        timer = explosionVFX.GetComponent<DestroyVFX>().timer;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Dependent on the game, get the reference
        if (gameManager.gameMode == GameMode.MainGame)
            waveSpawner = GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>();
        if (gameManager.gameMode == GameMode.EndlessMode)
            endlessSpawner = GameObject.Find("EndlessMode").GetComponent<EndlessSpawner>();
    }

    private void FixedUpdate() => CurrentHealth();

    private void CurrentHealth()
    {
        //When health reaches 0
        if (health <= 0)
        {
            //Change enemy state
            enemyController.enemyState = EnemyState.Dead;
            //Create VFX
            if (!spawnedVFX)
            {
                //Change bool
                spawnedVFX = true;
                //Create VFX
                Instantiate(explosionVFX, transform.position, Quaternion.identity);
            }
            //Call function
            Destroy();
        }
    }

    private void Destroy()
    {
        timer -= Time.deltaTime;
        //Destroy after particle completes
        if (timer <= 0)
        {
            //Based on game state, increment respective values
            if (gameManager.gameMode == GameMode.MainGame)
                waveSpawner.currentAmount++;
            if (gameManager.gameMode == GameMode.EndlessMode)
                endlessSpawner.enemiesDestroyed++;

            //Destroy
            Destroy(gameObject);
        }
    }

    public void EnemyDamaged(int damage)
    {
        //Remove health
        health -= damage;
    }
}
