///Code / Internal Documentation - File Name: DeathPlane
///Author's Name (s) & Student#: Kristopher Prince #301462555
///Program Description / Purpose: Kills the player when touched. Acts as the ground barrier to trigger death when the player falls. 
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField] private float death = 4.5f;
    [SerializeField] private PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth != null && playerHealth.gameObject.transform.position.y <= death)
        {
            playerHealth.Damage(999);
        }
    }
}
