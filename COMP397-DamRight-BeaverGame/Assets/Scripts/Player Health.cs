
///Code / Internal Documentation - File Name: PlayerHealth
///Author's Name (s) & Student#: Kristopher Prince #30146255 / Natashya Peddle  301487275
///Program Description / Purpose:
///Loads the gameover screen if health reaches 0, manages health: amount, getting hurt and healing. 

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
#if !UNITY_ANDROID
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
#endif
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
#if !UNITY_ANDROID
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
#endif
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
