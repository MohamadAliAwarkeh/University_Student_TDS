using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Private Variables
    private SpriteRenderer player;

    private void Start() => player = GameObject.Find("Player").GetComponent<SpriteRenderer>();

    private void Update() => DetectCollision();

    private void DetectCollision()
    {
        //Cache local variables
        Bounds playerBounds = player.bounds;

        //Checks if there is collision with the player
        if (this.GetComponent<SpriteRenderer>().bounds.Intersects(playerBounds))
        {
            //If it collides within the Y boundaries
        }
    }
}
