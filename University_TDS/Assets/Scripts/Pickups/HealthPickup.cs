using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Header("Health Settings")]
    public int healthAmount;

    //Private Variables
    private PlayerHealth playerHealth;

    private void Start() => playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

    private void Update() => SetPickupValue();

    private void SetPickupValue()
    {
        //If the pickup and the player collide
        if (this.GetComponent<SpriteRenderer>().bounds.Intersects(playerHealth.GetComponent<SpriteRenderer>().bounds) && playerHealth.health != 6)
        {
            //Give the player the respective health
            playerHealth.health += healthAmount;
            //Destroy obj
            Destroy(gameObject);
        }
    }
}
