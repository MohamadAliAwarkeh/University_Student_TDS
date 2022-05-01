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

    [Header("VFX")]
    public GameObject muzzleFlash;

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;

    //Private Variables
    private float fireRateCount;
    private float weaponSpreadWidth;

    public virtual void Update()
    {
        //Count down value
        fireRateCount -= Time.deltaTime;
    }

    public void Shoot()
    {
        //If conditions are met, shoot!
        if (fireRateCount <= 0)
        {
            //Reset
            fireRateCount = weaponFireRate;
            //Call function
            InstantiateBullet(bulletPrefab);
        }
    }

    public void InstantiateBullet(GameObject bullet)
    {
        //Call Function
        CreateMuzzleFlash();
        //Set spread
        weaponSpreadWidth = Random.Range(-weaponSpread, weaponSpread);
        //Create bullet
        Instantiate(bullet, fireFrom.position, fireFrom.rotation);
        //Apply spread
        bullet.transform.Rotate(0f, 0f, weaponSpreadWidth);
    }

    private void CreateMuzzleFlash()
    {
        //Create muzzle flash
        GameObject muzzle = Instantiate(muzzleFlash, fireFrom.position, fireFrom.rotation);
        //Attach to parent
        muzzle.transform.parent = fireFrom.transform;
    }
}
