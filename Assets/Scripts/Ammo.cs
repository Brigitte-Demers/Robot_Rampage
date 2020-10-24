using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows use of Dictionary Type.
using System.Collections.Generic;
using System.Diagnostics;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;

    // Tracks their respective ammunition types.
    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField]
    private int shotgunAmmo = 10;
    [SerializeField]
    private int assaultRifleAmmo = 50;

    public Dictionary<string, int> tagToAmmo;

    // Special method called before start.
    void Awake()
    {
        tagToAmmo = new Dictionary<string, int>
        {
            { Constants.Pistol , pistolAmmo },
            { Constants.Shotgun , shotgunAmmo },
            { Constants.AssaultRifle , assaultRifleAmmo },
        };
    }

    // Will add ammunition to the appropriate gun type.
    public void AddAmmo(string tag, int ammo)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            UnityEngine.Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        tagToAmmo[tag] += ammo;
    }

    // Returns true if gun has ammo.
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            UnityEngine.Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        return tagToAmmo[tag] > 0;
    }

    // Returns the bullet count for a gun type.
    public int GetAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            UnityEngine.Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        return tagToAmmo[tag];
    }

    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            UnityEngine.Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        tagToAmmo[tag]--;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
