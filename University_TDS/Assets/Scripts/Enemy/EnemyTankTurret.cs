using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankTurret : MonoBehaviour
{
    [Header("References")]
    public EnemyController enemyController;

    //Private Variables
    private Transform player;

    private void Start() => player = GameObject.Find("Player").GetComponent<Transform>();

    private void Update()
    {
        if (enemyController.enemyState == EnemyState.Shooting)
            TankTurretRotation();
    }

    public void TankTurretRotation()
    {
        //Getting the direction between the player and the object
        var direction = player.position - transform.position;
        //Calculate angle
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Finally, we roate the object with an offset
        this.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}
