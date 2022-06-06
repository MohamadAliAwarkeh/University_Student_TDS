using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVFX : MonoBehaviour
{
    [Header("Timer")]
    public float timer;

    public void Update()
    {
        //Countdown
        timer -= Time.deltaTime;
        //If timer reach 0, destroy
        if (timer <= 0)
            Destroy(gameObject);
    }
}
