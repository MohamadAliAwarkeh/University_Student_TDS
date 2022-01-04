using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseSpawn : MonoBehaviour
{
    [Header("Health Pickup")]
    public GameObject healthPrefab;
    public float timeBetweenSpawns;

    //Private Variables
    private float timer;

    private void Start() => timer = timeBetweenSpawns;

    private void Update()
    {
        //Simply checks if the object has a child or not! 
        if (transform.childCount > 0)
        {
            //Do nothing
        }
        else
        {
            //Counts down
            timer -= Time.deltaTime;
            //If timer reaches 0
            if (timer <= 0)
            {
                //Reset
                timer = timeBetweenSpawns;
                //Calls function
                RandomiseHealthSpawn();
            }
        }
    }

    private void RandomiseHealthSpawn()
    {
        //Randomise positions
        float x = Random.Range(-15f, 15f);
        float y = Random.Range(-8f, 8f);
        //Spawn object
        GameObject newHealth = Instantiate(healthPrefab, new Vector3(x, y, 0f), Quaternion.identity);
        newHealth.transform.parent = this.transform;
    }
}
