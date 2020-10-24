using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // The speed at which the gun will fire. 
    public float fireRate;
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
        // animation.
        GetComponentInChildren<Animator>().Play("Fire");
    }
}
