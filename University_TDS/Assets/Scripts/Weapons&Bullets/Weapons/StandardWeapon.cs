using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardWeapon : Weapon
{
    //Private variables
    private GameManager gameManager;

    private void Start()
    {
        //Get reference
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void Update()
    {
        //Get parent info
        base.Update();
    }

    private void FixedUpdate()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            //Press LMB to shoot
            if (Input.GetMouseButton(0))
                Shoot();
        }      
    }
}
