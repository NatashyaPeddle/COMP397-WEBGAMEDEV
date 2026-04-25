///Code / Internal Documentation - File Name: NPC Body
///Author's Name (s) & Student#: Kristopher Prince #301462555
///Program Description / Purpose: NPC Body Damage

using UnityEngine;

public class NPCBody : MonoBehaviour
{
    private float cooldown = 2f;
    private float lastDamage = -999f;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Time.time >= lastDamage + cooldown)
        {
            other.GetComponent<PlayerHealth>()?.Damage(1);
            lastDamage = Time.time;
        }
    }
}
