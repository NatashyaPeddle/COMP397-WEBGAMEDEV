//Natashya Peddle  301487275
using UnityEngine;

public class Beartrap : MonoBehaviour
{

    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Damage taken");

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        health.GetHurt(damageAmount);
        Destroy(gameObject);
    }
}
