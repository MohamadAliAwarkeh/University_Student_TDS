using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardWeapon : Weapon
{
    public override void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
            Shoot();        
    }
}
