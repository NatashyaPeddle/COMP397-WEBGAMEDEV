///Code / Internal Documentation - File Name: NPC
///Author's Name (s) & Student#: Kristopher Prince #301462555
///Program Description / Purpose: Manages the NPC entity, including waypoints, collisions, damage, chasing, speed etc. 

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

    [SerializeField] private AudioController audioController;
    private Vector3 destination;
    private Transform player;
    private int index;
    private bool isChasing = false;

    private int enemyHealth = 2;

    [SerializeField] private float normalSpeed = 7;
    [SerializeField] private float chaseSpeed = 10;

    private void OnValidate() => this.ValidateRefs();

     private void Awake()
    {
        if (audioController == null)
        {
            audioController = FindFirstObjectByType<AudioController>();
        }
    }

    void Start()
    {
        agent.speed = normalSpeed;

        if (waypoints.Count == 0) return;

        agent.destination = destination = waypoints[index].transform.position;
    }

    void Update()
    {
        if (waypoints.Count == 0) return;

        if (!isChasing && Vector3.Distance(transform.position, destination) < 5f)
        {
            index = (index + 1) % waypoints.Count;
            destination = waypoints[index].transform.position;
            agent.destination = destination;
        }

        if (isChasing && player != null)
        {
            agent.speed = chaseSpeed;
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
            audioController.PlayEnemyDefeatedSFX();
            Destroy(gameObject);
            EventChannelManager.Instance.killEvent.RaiseEvent();
        }

        else
        {
            audioController.PlayEnemyHurtSFX();
        }
    }
}
