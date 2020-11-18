using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Controls the zoom level.
    public float zoomFactor;
    // How far the gun can effectively shoot.
    public int range;
    // How much damage the guns cause.
    public int damage;

    // Field of view based on zoom factor.
    private float zoomFOV;
    private float zoomSpeed = 6;

    // The speed at which the gun will fire. 
    public float fireRate;
    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;
    // Tracks the last time the gun was fired.
    protected float lastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        // Sets lastFireTime to 10 seconds ago. When the player starts the game
        // they will be able to fire the gun immediately.
        lastFireTime = Time.time - 10;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected void Fire()
    {
        // Fetches the animation controller and tells it to play the "Fire"
        // animation. Checks if the player has any remaining ammunition, if so, play
        // the liveFire sound; otherwise, play dryFire sound.
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.ConsumeAmmo(tag);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }
        GetComponentInChildren<Animator>().Play("Fire");
    }
}
