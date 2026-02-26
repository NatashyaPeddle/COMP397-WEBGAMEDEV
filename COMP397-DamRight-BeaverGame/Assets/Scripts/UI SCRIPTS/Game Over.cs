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