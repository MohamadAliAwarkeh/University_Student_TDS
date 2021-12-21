using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float bulletDamage;
    public float bulletSpeed;
    public float bulletRange;

    [Header("VFX")]
    public GameObject bulletHitVFX;

    //Private Variables
    private float bulletLifetime;

    private void Start()
    {
        bulletLifetime = bulletRange;
    }

    private void Update()
    {
        //Call functions
        MoveBullet();
        BulletLifetime();
        CalculateCollision();
    }

    private void MoveBullet()
    {
        //Move bullet forward
        this.transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void BulletLifetime()
    {
        //counts lifeTIme down to 0, and then destroys bullet
        bulletLifetime -= Time.deltaTime;

        if (bulletLifetime <= 0)
            Destroy(gameObject);
    }

    private void CalculateCollision()
    {

    }
}
