//Natashya  301487275
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

            foreach (GameObject UIOnScreen in inGameUI)
            {
                if (UIOnScreen != null && UIOnScreen != InventoryPanel)
                {
                    UIOnScreen.SetActive(!isMenuOpen);
                }
            }
            GetComponent<PlayerInput>().enabled = false;

            InputSystem.actions.FindActionMap("Player").Disable(); //disable the action map for player

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            GetComponent<PlayerInput>().enabled = true;

            InputSystem.actions.FindActionMap("Player").Enable();

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
