//Natashya
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private bool isMenuOpen;
    
    private InputAction openMenu;

    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Inventory");
        openMenu.started += ToggleMenu;

        
    }

    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;

        
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        Debug.Log("open menu called pressing p");

        isMenuOpen = !isMenuOpen;


        InventoryPanel.SetActive(isMenuOpen);

        GameObject[] InGameUI = GameObject.FindGameObjectsWithTag("InGameUI");

        

        if (isMenuOpen)
        {

            foreach (GameObject UIOnScreen in InGameUI)
            {
                if (UIOnScreen != null && UIOnScreen != InventoryPanel)
                {
                    UIOnScreen.SetActive(false);
                }
            }

            GetComponent<PlayerInput>().enabled = false; ///disable the component

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
        }


    }



}
