using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : Bullet
{
    //Private Variables
    private Transform enemyParentObj;
    private int targetID;
    private int enemiesMax;
    private SpriteRenderer enemy;
    private EnemyHealth enemyHealth;
    private GameManager gameManager;

    public override void Start()
    {
        //Get parent info
        base.Start();
        //Setting references
        enemyParentObj = GameObject.Find("EnemyParentObj").transform;
        enemiesMax = enemyParentObj.childCount;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }

    public override void Update()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            //Get parent info
            base.Update();
            //Call function
            CalculateCollision();
        }
    }

    private void CalculateCollision()
    {
        //Checking if the current enemy hit fits witin the range
        if (targetID < enemiesMax && enemiesMax == enemyParentObj.childCount)
        {
            //Getting reference to the enemy body
            enemy = enemyParentObj.GetChild(targetID).GetChild(0).GetComponent<SpriteRenderer>();
            //Getting reference to the enemies health
            Transform baseEnemy = enemyParentObj.GetChild(targetID);
            enemyHealth = baseEnemy.GetComponent<EnemyHealth>();
            //Collision between bullet and enemy
            if (mySR.bounds.Intersects(enemy.bounds))
            {
                //Create VFX
                Instantiate(bulletHitVFX, this.transform.position, Quaternion.identity);
                //Deal damage to enemy
                enemyHealth.EnemyDamaged(bulletDamage);
                //Destroy
                Destroy(gameObject);
            }
        }
        else
        {
            targetID = -1;
            enemiesMax = enemyParentObj.childCount;
        }
        targetID++;
    }
}
