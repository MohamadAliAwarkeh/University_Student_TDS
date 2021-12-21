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
    //public float weaponsPerShot; //Attempt later fam

    [Header("VFX")]
    public GameObject muzzleFlash;

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;

    //Private Variables
    private float fireRateCount;
    private float weaponSpreadWidth;

    private void FixedUpdate()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        //Count down value
        fireRateCount -= Time.deltaTime;
        //If conditions are met, shoot!
        if (Input.GetMouseButton(0) && fireRateCount <= 0)
        {
            fireRateCount = weaponFireRate;
            InstantiateBullet();
        }
    }

    private void InstantiateBullet()
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
