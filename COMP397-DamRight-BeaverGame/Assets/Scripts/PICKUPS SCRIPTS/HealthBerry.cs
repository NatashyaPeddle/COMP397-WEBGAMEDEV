
///Code / Internal Documentation - File Name: HealthBerry
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Allows the player to pick up a berry and heal from it. 

using UnityEngine; 

public class HealthBerry : MonoBehaviour 
{
    public int healAmount = 1; 
    
    private void OnTriggerEnter(Collider other) { 
        
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            Debug.Log("Healing"); 
            health.Heal(healAmount); 
            Destroy(gameObject); 
        }
    } 
}