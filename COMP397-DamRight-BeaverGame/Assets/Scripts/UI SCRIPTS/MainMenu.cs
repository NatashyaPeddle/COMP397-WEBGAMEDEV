//Natashya Peddle  301487275a


using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    ///NEW GAME ----------------
    public void StartNewGame()
    {
        ///Add a Game Manager?
        ///Temporary Test menu
        SceneManager.LoadScene("LevelOne");
    }

    ///LOAD GAME ----------------
    public void LoadGame()
    {
        ///Doesn't need to be operational for A#1 P2
        SceneManager.LoadScene("LoadMenuSelection");
    }

    ///OPTIONS ----------------
    public void OpenMainOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    ///EXIT ----------------
    public void QuitGame()
    {
        #if !UNITY_EDITOR
        Application.Quit();
        #elif UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #   endif
    }

    ///BACK TO MAIN MENU -----------
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
