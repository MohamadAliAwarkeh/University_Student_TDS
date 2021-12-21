using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankTurret : MonoBehaviour
{
    //Private Variables
    private Transform player;

    private void Start() => player = GameObject.Find("Player").GetComponent<Transform>();

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
