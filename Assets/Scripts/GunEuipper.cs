using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEuipper : MonoBehaviour
{
    // references to each gun and tracks the currently equipped gun.
    public static string activeWeaponType;
    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;
    GameObject activeGun;

    // Start is called before the first frame update.
    void Start()
    {
        // Initializes the starting gun as the pistol.
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;
    }

    //////////////////////////////////////////
    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;
    }
    /////////////////////////////////////////

    // Update is called once per frame.
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
        }
        else if (Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
        }
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
