
///Code / Internal Documentation - File Name: CreateAmmo
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Allows the player to go to a tree asset, press a key and reload their ammo by chewing a tree. Reloads only by 1.

using UnityEngine;
using UnityEngine.InputSystem;

public class CreateAmmo : MonoBehaviour
{
    private bool InRange = false;
    private InputAction interact;

    [SerializeField] private AudioController audioController;

    private void Awake()
    {
        if (audioController == null)
        {
            audioController = FindFirstObjectByType<AudioController>();
        }
    }

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
            EventChannelManager.Instance.reloadEvent.RaiseEvent();
        }

        
    }

    private void createAmmo()
    {
        Debug.Log("Creating Ammo");

        PlayerShooter shooter = GameObject.FindWithTag("Player").GetComponent<PlayerShooter>();
        if (shooter != null)
        {
            audioController.PlayCrunchSFX();
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
