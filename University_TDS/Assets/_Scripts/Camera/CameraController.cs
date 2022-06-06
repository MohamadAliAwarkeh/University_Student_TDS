using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Follow Settings")]
    public GameObject followTarget;
    public float smoothTime;

    private void LateUpdate()
    {
        //Chace original position
        Vector3 originalPos = new Vector3(transform.position.x, transform.position.y, -10f);
        //Cache targets position
        Vector3 newPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10f);
        //Move camera smoothly
        transform.position = Vector3.Lerp(originalPos, newPos, Time.deltaTime * smoothTime);
    }
}
