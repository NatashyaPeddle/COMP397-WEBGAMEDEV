

///Code / Internal Documentation - File Name: Beartrap
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Causes the beartrap damage when the player walks over the item.

using UnityEngine;
using UnityEngine.InputSystem;

public class Beartrap : MonoBehaviour
{

    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            Debug.Log("Damage taken");
            health.GetHurt(damageAmount);
            Destroy(gameObject);
        }
    }

    
}
