
///Code / Internal Documentation - File Name: NPC LOS
///Author's Name (s) & Student#: Kristopher Prince #301462555
///Program Description / Purpose: Triggers NPC to follow and to stop following player. 

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
