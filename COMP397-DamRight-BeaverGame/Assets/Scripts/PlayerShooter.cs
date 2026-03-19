//Natashya Peddle  301487275
//Kristopher Prince #301462555

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField] private GameObject woodChunk;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private float projectileForce = 0f;
    [SerializeField] private AudioController audioController;

    private InputAction fire;
    public int ammo;
    public int maxAmmo = 7;

    private void Awake()
    {
        fire = InputSystem.actions.FindAction("Player/Attack");
        ammo = maxAmmo;

        if (audioController == null)
        {
            audioController = FindFirstObjectByType<AudioController>();
        }
    }

    private void OnEnable()
    {
        fire.started += Shoot;
    }

    private void OnDisable()
    {
        fire.started -= Shoot;
    }



    private void Shoot(InputAction.CallbackContext context)
    {

        if (ammo != 0)
        {
            audioController.PlayShootSFX();
            
            GameObject projectile = GameObject.Instantiate(woodChunk, projectileSpawn.position, projectileSpawn.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileForce, ForceMode.Impulse);

            ammo--;
            Destroy(projectile, 1.5f);
        }
    }

    //public void Reload()
    //{
    //    ammo = maxAmmo;
    //}

    public void Reload(int amount)
    {
        ammo += amount;

        if (ammo >= maxAmmo)
        {
            ammo = maxAmmo;
        }
    }
}
