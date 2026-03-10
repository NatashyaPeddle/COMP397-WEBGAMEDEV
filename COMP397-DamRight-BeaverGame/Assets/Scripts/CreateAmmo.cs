//Natashya Peddle  301487275
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateAmmo : MonoBehaviour
{
    private bool InRange = false;
    private InputAction interact;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Player/CreateAmmo");
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange && interact.WasPressedThisFrame())
        {
            createAmmo();
        }

        
    }



    private void createAmmo()
    {
        Debug.Log("Creating Ammo");

        PlayerShooter shooter = GameObject.FindWithTag("Player").GetComponent<PlayerShooter>();
        if (shooter != null)
        {
            shooter.Reload(1);
        }

        Destroy(gameObject);

        Debug.Log(shooter.ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = false;
        }
    }
}
