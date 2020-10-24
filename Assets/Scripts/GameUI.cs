using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows access to base Unity UI classes.
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    // The SerializeField attribute.Attributes allow you to convey information to the
    // C# runtime about particular classes.In this case, you are declaring that variables
    // are accessible from the Unity Inspector but not from other scripts.

    [SerializeField]
    Sprite redReticle;
    [SerializeField]
    Sprite yellowReticle;
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Image reticle;

    public void UpdateReticle()
    {
        switch (GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                reticle.sprite = redReticle;
                break;
            case Constants.Shotgun:
                reticle.sprite = yellowReticle;
                break;
            case Constants.AssaultRifle:
                reticle.sprite = blueReticle;
                break;
            default:
                return;
        }
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
