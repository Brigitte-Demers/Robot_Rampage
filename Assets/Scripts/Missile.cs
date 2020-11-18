using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // How fast the missile is.
    public float speed = 30f;

    // Damage the missile will deal upon hitting the payer.
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        // 1.
        // When you instantiate a missile, you start a coroutine called deathTimer(). This is
        // name of the method that the coroutine will call.
        StartCoroutine("deathTimer");
    }

    // Update is called once per frame
    void Update()
    {
        // 2.
        // Move the missile forward at speed multiplied by the time between frames.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator deathTimer()
    {
        // 3.
        // You'll notice that the method immediately returns a WaitForSeconds, set to 10. Once
        // those 10 seconds have passed, the method will resume after the yield statement. If
        // the missile doesn’t hit the player, it should auto-destruct.
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    // The script checks if the Missile GameObject collided with the Player GameObject
    // based on its tag.It also checks to see if if the player is still active, since the Player
    // component will be disabled later in the game-over state. If so, it tells the Player script
    // to take damage and passes along its damage value. Once the missile hits the player, it
    // destroys itself.
        void OnCollisionEnter(Collision collider)
        {
            if (collider.gameObject.GetComponent<Player>() != null
            && collider.gameObject.tag == "Player")
            {
                collider.gameObject.GetComponent<Player>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
}
