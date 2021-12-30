using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandardBullet : Bullet
{
    //Private Variables
    public SpriteRenderer playerCol;
    public PlayerHealth playerHealth;

    public override void Start()
    {
        //Get parent info
        base.Start();
        //Setting references
        playerCol = GameObject.Find("PlayerBody").GetComponent<SpriteRenderer>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    public override void Update()
    {
        //Get parent info
        base.Update();
        //Call function
        DetectCollision();
    }

    private void DetectCollision()
    {
        //If the bullet intersects with the player, then...
        if (mySR.bounds.Intersects(playerCol.bounds))
        {
            //Create VFX
            Instantiate(bulletHitVFX, this.transform.position, Quaternion.identity);
            //Deal damage
            playerHealth.PlayerDamaged(bulletDamage);
            //Destroy
            Destroy(gameObject);
        }
    }
}
