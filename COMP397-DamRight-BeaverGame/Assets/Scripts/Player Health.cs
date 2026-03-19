//Kristopher Prince #30146255
//Natashya Peddle  301487275

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    [SerializeField] private AudioController audioController;

    private void Awake()
    {
        if (audioController == null)
        {
            audioController = FindFirstObjectByType<AudioController>();
        }
    }

    void Start()
    {
        health = maxHealth;
    }

    public void Damage(int amount)
    {
        audioController.PlayPlayerHurtSFX();
        health -= amount;
        if (health <= 0)
        {
            audioController.PlayDeathSFX();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    public void GetHurt (int amount)
    {

        if (health != 0)
        {
            audioController.PlayPlayerHurtSFX();
            health -= amount;
        }

        if(health <= 0)
        {
            audioController.PlayDeathSFX();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    public void Heal(int amount)
    {
        if (health != maxHealth)
        {
            audioController.PlayPlayerHealSFX();
            health += amount;
        }
    }
}
