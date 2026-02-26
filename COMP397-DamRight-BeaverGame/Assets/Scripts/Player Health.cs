//Kristopher Prince #301462555

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    void Start()
    {
        health = maxHealth;
    }

    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    public void Heal(int amount)
    {
        if (health != maxHealth)
        {
            health += amount;
        }
    }
}
