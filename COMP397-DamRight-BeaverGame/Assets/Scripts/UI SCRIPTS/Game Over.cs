///Code / Internal Documentation - File Name: Game Over
///Author's Name (s) & Student#: Kristopher Prince #301462555
///Program Description / Purpose: Creates the gameover screen which appears upon player death. The buttons are functional. 

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}