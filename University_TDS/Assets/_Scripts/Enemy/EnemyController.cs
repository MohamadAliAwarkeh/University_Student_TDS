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

    //Private Variables
    private GameObject player;
    private GameManager gameManager;

    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            switch (enemyState)
            {
                case EnemyState.Moving:
                    EnemyMove();
                    break;

                case EnemyState.Shooting:
                    //Function is called in the EnemyTankTurret.cs
                    break;

                case EnemyState.Reloading:
                    //Functions are called in the EnemyStandardWeapon.cs
                    break;

                case EnemyState.Dead:
                    break;
            }
        }
    }

    public void EnemyMove()
    {
        //Only rotate when moving
        tankBody.TankBodyRotation();
        //Move towards the player
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        //If in range, switch states
        if (firingRange.GetComponent<SpriteRenderer>().bounds.Intersects(player.GetComponent<SpriteRenderer>().bounds))
            enemyState = EnemyState.Shooting;
    }
}

public enum EnemyState
{
    Moving,
    Shooting,
    Reloading,
    Dead
}