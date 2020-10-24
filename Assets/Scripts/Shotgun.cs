using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    override protected void Update()
    {
        base.Update();
        // Shotgun & Pistol have semi-auto fire rate
        // I changed the fire rate of the shotgun and the pistol because I did not
        // like the feel of the fire rate from the text book.
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