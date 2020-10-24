using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    override protected void Update()
    {
        base.Update();
        // Shotgun & Pistol have semi-auto fire rate
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime)
             > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
    // This checks whether enough time has elapsed between shots to allow for 
    // another shot to be taken.
}