using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLoadout : MonoBehaviour
{
    [Header("Body Settings")]
    public SpriteRenderer tankBody;
    public PlayerController playerController;
    public PlayerHealth playerHealth;
    
    [Header("Weapon & Bullets")]
    public SpriteRenderer tankTurret;
    public Weapon weapon;
}
