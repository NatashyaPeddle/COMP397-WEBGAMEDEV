//Kristopher Prince #301462555

using UnityEngine;
using KBCore.Refs;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Linq;


[RequireComponent(typeof(NavMeshAgent))]

public class NPC : MonoBehaviour
{
    [SerializeField, Self] private NavMeshAgent agent;
    [SerializeField] private Collider bodyCollider;
    [SerializeField] private Collider losCollider;
    [SerializeField] private List<GameObject> waypoints = new List<GameObject>();
    private Vector3 destination;
    private Transform player;
    private int index;
    private bool isChasing = false;

    private int enemyHealth = 2;

    private void OnValidate() => this.ValidateRefs();

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint").ToList();

        if (waypoints.Count < 0) return;

        agent.destination = destination = waypoints[index].transform.position;
    }

    void Update()
    {
        if (waypoints.Count < 0) return;

        if (!isChasing && Vector3.Distance(transform.position, destination) < 5f)
        {
            index = (index + 1) % waypoints.Count;
            destination = waypoints[index].transform.position;
            agent.destination = destination;
        }

        if (isChasing && player != null)
        {
            agent.destination = player.position;
        }
    }

    public void StartChasing(Transform playerTransform)
    {
        player = playerTransform;
        isChasing = true;
    }

    public void StopChasing()
    {
        player = null;
        isChasing = false;
        agent.ResetPath();
    }

    public void Damage(int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
