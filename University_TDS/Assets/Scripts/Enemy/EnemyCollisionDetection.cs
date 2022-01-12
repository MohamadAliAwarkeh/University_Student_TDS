using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    public SpriteRenderer mySR;
    private EnemyController enemyController;
    private SpriteRenderer player;

    private void Start()
    {
        player = GameObject.Find("PlayerBody").GetComponent<SpriteRenderer>();
        enemyController = this.GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        //if (mySR.bounds.Intersects(player.bounds))
        //{
        //    //Do not move
        //}
        //if (!mySR.bounds.Intersects(player.bounds))
        //    enemyController.EnemyMove();
    }
}
