//Kristopher Prince #301462555

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InputAction openMenu;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private bool isMenuOpen;
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;
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
            GetComponent<PlayerInput>().enabled = false;
            InputSystem.actions.FindActionMap("Player").Disable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else
        {
            GetComponent<PlayerInput>().enabled = true;
            InputSystem.actions.FindActionMap("Player").Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
