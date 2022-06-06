using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private SpriteRenderer mySR;
    private SpriteRenderer playerSR;

    private void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        playerSR = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    private void Update() => HandleCollisions();

    private void HandleCollisions()
    {
        //Handle Player Collision
        if (mySR.bounds.Intersects(playerSR.bounds))
            Destroy(gameObject);
    }

}
