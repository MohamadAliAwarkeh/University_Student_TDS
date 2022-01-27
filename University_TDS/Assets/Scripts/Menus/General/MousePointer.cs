using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [Header("Mouse Settings")]
    public Vector3 offsetPos;

    private void Update()
    {
        //Simply sets the objects position to the mouse
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offsetPos;
    }
}
