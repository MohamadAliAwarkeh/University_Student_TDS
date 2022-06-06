using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretRotation : MonoBehaviour
{
    public void RotateTurret()
    {
        //Getting the direction between the mouse and our position
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //Calculate angle
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Finally, we roate the object with an offset
        this.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}
