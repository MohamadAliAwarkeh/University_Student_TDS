using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int health;

    [Header("VFX")]
    public GameObject explosionVFX;
    public bool hasRarityBorder;
    public bool hasMultipleWeapons;
    public Color destroyedColour = new Color (0.25f, 0.25f, 0.25f, 1);

    [Header("References")]
    public EnemyController enemyController;
    public SpriteRenderer bodySR, weaponSR, weaponSR2;
    public SpriteRenderer bodyRaritySR, weaponRaritySR, weaponRaritySR2;

    //Private Variables
    private bool spawnedVFX;
    private bool hasBeenDestroyed;
    private float timer;
    private WaveSpawner waveSpawner;
    private EndlessScoreboard endlessSpawner;
    private GameManager gameManager;
    private GameObject newParent;

    private void Start()
    {
        //Get general things
        newParent = GameObject.Find("DeadEnemyParent");

        //Get references
        timer = explosionVFX.GetComponent<DestroyVFX>().timer;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Dependent on the game mode, get the reference
        if (gameManager.gameMode == GameMode.MainGame)
            waveSpawner = GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>();
        if (gameManager.gameMode == GameMode.EndlessMode)
            endlessSpawner = GameObject.Find("EndlessMode").GetComponent<EndlessScoreboard>();
    }

    private void FixedUpdate() => CurrentHealth();

    private void CurrentHealth()
    {
        //When health reaches 0
        if (health <= 0)
        {
            //Change enemy state
            enemyController.enemyState = EnemyState.Dead;

            //Return
            if (hasBeenDestroyed)
                return;

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
        //Count down
        timer -= Time.deltaTime;
        //Destroy after particle completes
        if (timer <= 0)
        {

            //Based on game state, increment respective values
            if (gameManager.gameMode == GameMode.MainGame)
                waveSpawner.currentAmount++;
            if (gameManager.gameMode == GameMode.EndlessMode)
                endlessSpawner.enemiesDestroyed++;

            hasBeenDestroyed = true;

            //Destroy
            DeadVFX();
        }
    }

    private void DeadVFX()
    {
        //Change colours
        bodySR.color = destroyedColour;
        weaponSR.color = destroyedColour;
        //Change layers
        bodySR.sortingOrder = 0;
        weaponSR.sortingOrder = 0;
        if (hasRarityBorder)
        { 
            //Change colour
            bodyRaritySR.color = new Color(0, 0, 0, 0);
            weaponRaritySR.color = new Color(0, 0, 0, 0);
            //Change layer
            bodyRaritySR.sortingOrder = 0;
            weaponRaritySR.sortingOrder = 0;
        }
        if (hasMultipleWeapons)
        {
            weaponSR2.color = destroyedColour;
            weaponSR2.sortingOrder = 0;
        }
        if (hasRarityBorder && hasMultipleWeapons)
        {
            //Change colour
            bodyRaritySR.color = new Color(0, 0, 0, 0);
            weaponRaritySR.color = new Color(0, 0, 0, 0);
            weaponRaritySR2.color = new Color(0, 0, 0, 0);
            //Change layer
            bodyRaritySR.sortingOrder = 0;
            weaponRaritySR.sortingOrder = 0;
            weaponRaritySR2.sortingOrder = 0;

        }
        //Change parent
        this.transform.parent = newParent.transform;
    }

    public void EnemyDamaged(int damage)
    {
        //Remove health
        health -= damage;
    }
}
