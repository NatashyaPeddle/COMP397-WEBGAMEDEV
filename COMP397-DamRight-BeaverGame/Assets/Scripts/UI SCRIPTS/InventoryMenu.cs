///Code / Internal Documentation - File Name: InventoryMenu
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Opens/closes inventory, allows player to use cursor, 

using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private bool isMenuOpen;

    private GameObject[] inGameUI;
    
    private InputAction openMenu;

    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Inventory");
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


        InventoryPanel.SetActive(isMenuOpen);


        

        if (isMenuOpen)
        {
            InventoryPanel.SetActive(true);

            BonusScore.Instance.updateScoreUI();

            foreach (GameObject UIOnScreen in inGameUI)
            {
                if (UIOnScreen != null && UIOnScreen != InventoryPanel)
                {
                    UIOnScreen.SetActive(!isMenuOpen);
                }
            }

            InputSystem.actions.FindActionMap("Player").Disable(); //disable the action map for player
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            InputSystem.actions.FindActionMap("Player").Enable();
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            foreach (GameObject UIOnScreen in inGameUI)
            {
                if (UIOnScreen != null && UIOnScreen != InventoryPanel)
                {
                    UIOnScreen.SetActive(!isMenuOpen);
                }
            }
        }


    }



}
