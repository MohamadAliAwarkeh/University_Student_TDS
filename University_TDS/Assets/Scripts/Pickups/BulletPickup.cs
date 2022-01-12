using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    [Header("BulletType")]
    public BulletType bulletType;

    //Private variables
    private SpriteRenderer player;
    private StandardWeapon playerWeapon;

    private void Start()
    {
        player = GameObject.Find("PlayerBody").GetComponent<SpriteRenderer>();
        playerWeapon = GameObject.Find("StandardWeapon").GetComponent<StandardWeapon>();
    }

    private void Update() => ChangeBulletType();

    private void ChangeBulletType()
    {
        //Local cached variable
        SpriteRenderer mySR = this.GetComponent<SpriteRenderer>();
        //If the pickup and player collide
        if (mySR.bounds.Intersects(player.bounds))
        {
            //Change the bullet type based on the selected pickup
            switch (bulletType)
            {
                case BulletType.Standard:
                    playerWeapon.bulletPrefab = playerWeapon.standardBullet;
                    break;

                case BulletType.Sniper:
                    playerWeapon.bulletPrefab = playerWeapon.sniperBullet;
                    break;

                case BulletType.Big:
                    playerWeapon.bulletPrefab = playerWeapon.bigBullet;
                    break;
            }
            //Destroy
            Destroy(gameObject);
        }
    }
}

public enum BulletType
{
    Standard,
    Sniper,
    Big
}
