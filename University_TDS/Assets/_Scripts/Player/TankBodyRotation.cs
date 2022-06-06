using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBodyRotation : MonoBehaviour
{
    public void RotateBody()
    {
        //Rotate forward
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //Rotate backwards
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        //Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        //Rotate Right
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
}
