using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public int bulletDamage;
    public float bulletSpeed;
    public float bulletRange;

    [Header("VFX")]
    public GameObject bulletHitVFX;

    //Private Variables
    private float bulletLifetime;
    [HideInInspector] public SpriteRenderer mySR;

    public virtual void Start()
    {
        //Setting max lifetime
        bulletLifetime = bulletRange;
        //Setting SR
        mySR = this.GetComponent<SpriteRenderer>();
    }

    public virtual void Update()
    {
        //Call functions
        MoveBullet();
        BulletLifetime();
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
}
