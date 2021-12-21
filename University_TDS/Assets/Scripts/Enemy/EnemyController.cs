using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy State")]
    public EnemyState enemyState;

    [Header("Enemy Settings")]
    public float enemySpeed;
    [Space(10)]
    public SpriteRenderer firingRange;

    [Header("References")]
    public EnemyTankBody tankBody;
    public EnemyTankTurret tankTurret;

    //Private Variables
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Moving:
                EnemyMove();
                break;

            case EnemyState.Shooting:
                EnemyShooting();
                break;

            case EnemyState.Reloading:
                EnemyReloading();
                break;

            case EnemyState.Dead:
                break;
        }
    }

    private void EnemyMove()
    {
        //Call function
        tankBody.TankBodyRotation();
        //Move enemy towards player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);

        if (firingRange.GetComponent<SpriteRenderer>().bounds.Intersects(player.GetComponent<SpriteRenderer>().bounds))
            enemyState = EnemyState.Shooting;
    }

    private void EnemyShooting()
    {
        //Call function
        tankTurret.TankTurretRotation();
    }

    private void EnemyReloading()
    {

    }
}

public enum EnemyState
{
    Moving,
    Shooting,
    Reloading,
    Dead
}
