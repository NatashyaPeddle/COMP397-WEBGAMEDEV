using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{
    private InputAction openMenu;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Slider mouseSensibilitySlider;
    [SerializeField] private bool isMenuOpen;
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;
        mouseSensibilitySlider.onValueChanged.AddListener(delegate {OnValueChangedRuntime(mouseSensibilitySlider.value);});
    }

    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;
        mouseSensibilitySlider.onValueChanged.RemoveListener(delegate {OnValueChangedRuntime(mouseSensibilitySlider.value);});
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

    private void OnValueChangedRuntime(float value)
    {
        Debug.Log($"MenuInput value changed - {value}");
    }
}
