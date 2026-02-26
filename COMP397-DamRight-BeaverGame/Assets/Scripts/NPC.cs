//Kristopher Prince #301462555

using UnityEngine;
using KBCore.Refs;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

public class NPC : MonoBehaviour
{
    [SerializeField, Self] private NavMeshAgent agent;
    [SerializeField] private Collider bodyCollider;
    [SerializeField] private Collider losCollider;
    private Transform player;
    private bool isChasing = false;

    private int enemyHealth = 2;

    private void OnValidate() => this.ValidateRefs();

    void Update()
    {
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
