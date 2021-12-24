using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("General Settings")]
    public Transform fireFrom;

    [Header("Weapon Settings")]
    public float weaponFireRate;
    public float weaponSpread;
    public int bulletsPerShot;

    [Header("VFX")]
    public GameObject muzzleFlash;

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;

    //Private Variables
    private float fireRateCount;
    private float weaponSpreadWidth;
    private int bulletsCreated;

    public virtual void Update()
    {
        //Count down value
        fireRateCount -= Time.deltaTime;

        //Reset value
        if (bulletsCreated <= 0)
            bulletsCreated = bulletsPerShot;
    }

    public void Shoot()
    {
        //If conditions are met, shoot!
        if (fireRateCount <= 0)
        {
            //Reset
            fireRateCount = weaponFireRate;
            //Call function
            InstantiateBullet();
        }
    }

    //Simply does a loop to create multiple bullets
    public void InstantiateBullets()
    {
        if (bulletsCreated > 0)
        {
            InstantiateBullet();
            bulletsCreated--;
        }
    }

    public void InstantiateBullet()
    {
        //Call Function
        CreateMuzzleFlash();
        //Set spread
        weaponSpreadWidth = Random.Range(-weaponSpread, weaponSpread);
        //Create bullet
        GameObject newBullet = Instantiate(bulletPrefab, fireFrom.position, fireFrom.rotation);
        //Apply spread
        newBullet.transform.Rotate(0f, 0f, weaponSpreadWidth);
    }

    private void CreateMuzzleFlash()
    {
        //Create muzzle flash
        GameObject muzzle = Instantiate(muzzleFlash, fireFrom.position, fireFrom.rotation);
        //Attach to parent
        muzzle.transform.parent = fireFrom.transform;
    }
}
