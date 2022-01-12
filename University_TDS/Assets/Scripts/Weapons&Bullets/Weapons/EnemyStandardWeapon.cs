using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandardWeapon : Weapon
{
    [Header("Shooting Timers")]
    public float shootingPeriod;
    public float reloadingPeriod;

    [Header("Reference")]
    public EnemyController enemyController;

    //Private Variables
    private bool canShoot;
    private float timeToShoot;
    private float timeToReload;
    private SpriteRenderer mySR;
    private Color activeColour = new Color(1f, 1f, 1f);
    private Color disabledColour = new Color(0.5f, 0.5f, 0.5f);
    private GameManager gameManager;

    private void Start()
    {
        //Set values
        canShoot = true;
        timeToShoot = shootingPeriod;
        timeToReload = reloadingPeriod;

        //Get reference
        mySR = this.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void Update()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            //Get inital information
            base.Update();

            //Call functions based on the enemy state
            if (enemyController.enemyState == EnemyState.Moving)
                mySR.color = disabledColour;

            if (enemyController.enemyState == EnemyState.Shooting)
                HandleEnemyShooting();

            if (enemyController.enemyState == EnemyState.Reloading)
                HandleEnemyReload();
        }    
    }

    public void HandleEnemyShooting()
    {
        if (canShoot)
        {
            //Set colour
            mySR.color = activeColour;
            //Fire the weapon
            Shoot();
            //Count down time remaining to shoot
            timeToShoot -= Time.deltaTime;

            if (timeToShoot <= 0)
            {
                //Reset time
                timeToShoot = shootingPeriod;
                //Change bool
                canShoot = false;
                //Switch state
                enemyController.enemyState = EnemyState.Reloading;
            }
        }
    }

    public void HandleEnemyReload()
    {
        if (!canShoot)
        {
            //Count down time it takes to reload
            timeToReload -= Time.deltaTime;

            if (timeToReload <= 0)
            {
                //Reset timer
                timeToReload = reloadingPeriod;
                //Change bool
                canShoot = true;
                //Switch state
                enemyController.enemyState = EnemyState.Moving;
            }
        }
    }
}
