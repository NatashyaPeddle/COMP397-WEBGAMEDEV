//Kristopher Prince 301462555

using UnityEngine;

public class NPCLOS : MonoBehaviour
{
    public NPC npc;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            npc.StartChasing(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            npc.StopChasing();
        }
    }
}
