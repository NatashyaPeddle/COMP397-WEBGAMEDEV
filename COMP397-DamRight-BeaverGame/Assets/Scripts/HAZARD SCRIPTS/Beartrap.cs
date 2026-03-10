//Natashya Peddle  301487275
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
