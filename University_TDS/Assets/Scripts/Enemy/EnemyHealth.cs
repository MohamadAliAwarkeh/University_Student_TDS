using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int health;

    [Header("VFX")]
    public GameObject explosionVFX;

    [Header("References")]
    public EnemyController enemyController;

    //Private Variables
    private bool spawnedVFX;
    private float timer;
    private WaveSpawner waveSpawner;

    private void Start()
    {
        timer = explosionVFX.GetComponent<DestroyVFX>().timer;
        waveSpawner = GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>();
    }

    private void FixedUpdate()
    {
        CurrentHealth();
    }

    private void CurrentHealth()
    {

        //When health reaches 0
        if (health == 0)
        {
            //Change enemy state
            enemyController.enemyState = EnemyState.Dead;
            //Create VFX
            if (!spawnedVFX)
            {
                //Change bool
                spawnedVFX = true;
                //Create VFX
                GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            }
            //Call function
            Destroy();
        }
    }

    private void Destroy()
    {
        timer -= Time.deltaTime;
        //Destroy after particle completes
        if (timer <= 0)
        {
            //Increment
            waveSpawner.currentAmount++;
            //Destroy
            Destroy(gameObject);
        }
    }

    public void EnemyDamaged(int damage)
    {
        //remove health
        health -= damage;
    }
}
