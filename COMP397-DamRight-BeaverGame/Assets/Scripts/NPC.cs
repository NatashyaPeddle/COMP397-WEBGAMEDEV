using UnityEngine;
using KBCore.Refs;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

public class NPC : MonoBehaviour
{
    [SerializeField, Self] private NavMeshAgent agent;

    private Transform player;
    private bool isChasing = false;

    private void OnValidate() => this.ValidateRefs();

    void Update()
    {
        if (isChasing && player != null)
        {
            agent.destination = player.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            isChasing = true; 
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;
            player = null;
            agent.ResetPath();
        }
    }
}
