using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandardBullet : Bullet
{
    //Private Variables
    public SpriteRenderer playerCol;
    private PlayerHealth playerHealth;
    private GameManager gameManager;

    public override void Start()
    {
        //Get parent info
        base.Start();
        //Setting references
        playerCol = GameObject.Find("PlayerBody").GetComponent<SpriteRenderer>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void Update()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            //Get parent info
            base.Update();
            //Call function
            DetectCollision();
        }      
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
