using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // Obviously, the prefab for the missile.
    [SerializeField]
    GameObject missileprefab;

    // Robot type is the type of robot. The red, blue or yellow robot's
    // to be specific.
    [SerializeField]
    private string robotType;

    public Animator robot;

    // How much damage this robot can take before being destroyed.
    public int health;

    // Distance their guns can fire.
    public int range;

    //How fast their guns can fire.
    public float fireRate;

    public Transform missileFireSpot;

    // Agent is a reference to the NavMesh Agent Component.
    UnityEngine.AI.NavMeshAgent agent;

    // What the robot's should be tracking.
    private Transform player;
    private float timeLastFired;

    // Tracks whether or not the robot is dead/destroyed.
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        // 1.
        // By default, all robots are alive. By setting the agent and player values
        // to the NavMesh Agent and Player components respectively.
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 2. 
        // Check if the robot is dead before continuing. There are no
        // zombie robots in this game!
        if (isDead)
        {
            return;
        }

        // 3.
        // Makes the robot face the player.
        transform.LookAt(player);

        // 4.
        // Tells the robot to use the NavMesh to find the player.
        agent.SetDestination(player.position);

        // 5.
        // Checks to see if the robot is within firing range and if there's been enough
        // time between shots to fire again.
        if (Vector3.Distance(transform.position, player.position) < range
        && Time.time - timeLastFired > fireRate)
        {
            // 6.
            // Updates timeLastFired to the current time and calls Fire(), which simply logs a
            // message to the console for the time being.
            timeLastFired = Time.time;
            fire();
        }
    }

    private void fire()
    {
        GameObject missile = Instantiate(missileprefab);
        missile.transform.position = missileFireSpot.transform.position;
        missile.transform.rotation = missileFireSpot.transform.rotation;
        robot.Play("Fire");
    }
}
