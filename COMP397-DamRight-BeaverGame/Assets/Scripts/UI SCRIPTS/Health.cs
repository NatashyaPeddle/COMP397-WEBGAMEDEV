///Code / Internal Documentation - File Name: Health
///Author's Name (s) & Student#: Kristopher Prince #301462555
///Program Description / Purpose: Creates / manages player health and UI: increasing and decreasing. 

using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
   private int health;
   private int maxHealth;
   public Sprite emptyHeart;
   public Sprite heart;
   public Image[] hearts;

   public PlayerHealth playerHealth;




   void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = heart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
