
///Code / Internal Documentation - File Name: MainMenu
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Manages the main menu screen and button functionality. Allows the player to go to a different screen/level or exit.


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button saveBtn;
    [SerializeField] private Button loadBtn;

    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject pcControls;
    [SerializeField] private GameObject mobileControls;

    private void Start()
    {
        saveBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.SaveGame("Save1");
        });

        loadBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.LoadGame("Save1");
        });


    }



    ///NEW GAME ----------------
    public void StartNewGame()
    {
        ///Add a Game Manager?
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelOne");
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
#endif
    }

    public void Controls()
    {
        controlsPanel.SetActive(true);

#if UNITY_ANDROID
        mobileControls.SetActive(true);
        pcControls.SetActive(false);
#else   
        pcControls.SetActive(true);
        mobileControls.SetActive(false);
#endif
    }

    public void ReturnControls()
    {
        controlsPanel.SetActive(false);
        mobileControls.SetActive(false);
        pcControls.SetActive(false);
    }

    ///BACK TO MAIN MENU -----------
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
