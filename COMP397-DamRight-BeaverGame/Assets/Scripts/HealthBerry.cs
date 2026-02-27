//Natashya Peddle
using System; 
using UnityEngine; 

public class HealthBerry : MonoBehaviour 
{
    public int healAmount = 1; 
    
    private void OnTriggerEnter(Collider other) { 
        Debug.Log("Healing"); 
        
        PlayerHealth health = other.GetComponent<PlayerHealth>(); 
        health.Heal(healAmount); 
        Destroy(gameObject); 
    } 
}