using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Health is the remaining life of the player.
    public int health;
    // Armour is a special health layer for the player that results in 50% reduced damage.
    public int armor;
    // References its respective script.
    public GameUI gameUI;
    // References its respective script.
    private GunEquipper gunEquipper;
    // Reference to the ammo class to keep track of weapon ammo.
    private Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        // This just gets the Ammo and GunEquipper component attached to the Player GameObject.
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // TakeDamage() takes the incoming damage and reduces its amount based on how much
    // armor the player has remaining.If the player has no armor, then you apply the total
    // damage to the player’s health. If health reaches zero, it’s game over for the player; 
    // for now, you just log this to the console.
    public void TakeDamage(int amount)
    {
        int healthDamage = amount;

        if (armor > 0)
        {
            int effectiveArmor = armor * 2;

            effectiveArmor -= healthDamage;

            // If there is still armor, don't need to process
            // health damage
            if (effectiveArmor > 0)
            {
                armor = effectiveArmor / 2;
                return;
            }
            armor = 0;
        }

        health -= healthDamage;
        Debug.Log("Health is " + health);

        if (health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
