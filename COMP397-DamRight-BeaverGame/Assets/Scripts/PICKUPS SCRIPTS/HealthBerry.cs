//Natashya Peddle  301487275

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