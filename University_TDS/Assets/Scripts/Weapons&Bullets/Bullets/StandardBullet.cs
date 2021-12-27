using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : Bullet
{
    //Private Variables
    [SerializeField] private Transform enemyParentObj;
    [SerializeField] private int targetID;
    [SerializeField] private int enemiesMax;
    [SerializeField] private SpriteRenderer enemy;
    [SerializeField] private EnemyHealth enemyHealth;

    public override void Start()
    {
        //Get parent info
        base.Start();
        //Setting references
        enemyParentObj = GameObject.Find("EnemyParentObj").transform;
        enemiesMax = enemyParentObj.childCount;
    }

    public override void Update()
    {
        //Get parent info
        base.Update();
        //Call function
        CalculateCollision();
    }

    private void CalculateCollision()
    {
        //Checking if the current enemy hit fits witin the max
        if (targetID < enemiesMax)
        {
            //Getting reference to the enemy HIT
            enemy = enemyParentObj.GetChild(targetID).GetComponent<SpriteRenderer>();
            //Getting reference to the enemies health
            enemyHealth = enemy.GetComponent<EnemyHealth>();
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
    }
}
