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

    private void Start()
    {
        canShoot = true;
        timeToShoot = shootingPeriod;
        timeToReload = reloadingPeriod;
    }

    public override void Update()
    {
        //Get inital information
        base.Update();

        //set function
        if (enemyController.enemyState == EnemyState.Shooting)
            HandleEnemyShooting();

        if (enemyController.enemyState == EnemyState.Reloading)
            HandleEnemyReload();
    }

    public void HandleEnemyShooting()
    {
        if (canShoot)
        {
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
