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

    [Header("Colours")]
    public bool hasRarityBorder;
    public Color destroyedColour;
    public SpriteRenderer raritySR;

    //Private Variables
    private float bulletLifetime;
    [HideInInspector] public SpriteRenderer mySR;
    [HideInInspector] public BulletState bulletState;

    public virtual void Start()
    {
        //Setting max lifetime
        bulletLifetime = bulletRange;
        //Setting SR
        mySR = this.GetComponent<SpriteRenderer>();

    }

    public virtual void Update()
    {
        BulletLifetime();

        //Call functions
        if (bulletState == BulletState.Alive)
            MoveBullet();
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
            BulletDead();
    }

    private void BulletDead()
    {
        mySR.color = destroyedColour;
        mySR.sortingOrder = 0;
        bulletState = BulletState.Dead;

        if (hasRarityBorder)
            raritySR.color = new Color(0, 0, 0, 0);
    }
}

public enum BulletState
{
    Alive,
    Dead
}
