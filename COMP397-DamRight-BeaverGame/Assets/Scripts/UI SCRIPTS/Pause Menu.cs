
///Code / Internal Documentation - File Name: Pause Menu
///Author's Name (s) & Student#: Kristopher Prince #301462555
///Program Description / Purpose: Creates the pause menu and allows the player to open and close it. All buttons are functional. 

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InputAction openMenu;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private bool isMenuOpen;
    [SerializeField] private GameObject InventoryPanel;
    private GameObject[] inGameUI;
    
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;
        inGameUI = GameObject.FindGameObjectsWithTag("InGameUI");
    }

    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);

        if (isMenuOpen)
        {
             foreach (GameObject UIOnScreen in inGameUI)
            {
                if (UIOnScreen != null && UIOnScreen != InventoryPanel)
                {
                    UIOnScreen.SetActive(!isMenuOpen);
                }
            }

            InputSystem.actions.FindActionMap("Player").Disable();
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else
        {
             foreach (GameObject UIOnScreen in inGameUI)
            {
                if (UIOnScreen != null && UIOnScreen != InventoryPanel)
                {
                    UIOnScreen.SetActive(!isMenuOpen);
                }
            }

            InputSystem.actions.FindActionMap("Player").Enable();
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}