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
        if (this.GetComponent<SpriteRenderer>().bounds.Intersects(playerHealth.GetComponent<SpriteRenderer>().bounds) && playerHealth.health != 6)
        {
            playerHealth.health += healthAmount;
            Destroy(gameObject);
        }
    }
}
