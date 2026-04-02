//Kristopher Prince #301462555
//Natashya Peddle  301487275

///Code / Internal Documentation - File Name: PlayerInput
///Author's Name (s) & Student#: Kristopher Prince #301462555 / Natashya Peddle #301487275
///Program Description / Purpose: Manages player input and correlates to an action/movement. This also controls the player camera & mouse sensitivity. 

using KBCore.Refs;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    ///INPUT ACTIONS -------------------
    private InputAction move;
    private InputAction look;
    private InputAction jump;

    
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -30.0f;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private float mouseSensY = 8.0f;
    [SerializeField, Child] private Camera cam;
    [SerializeField] private float mobileScale = 10.0f;

    //JUMP CONTROLS
    private float jumpHeight = 1.0f;
    private Vector3 jumping;
    private bool isGrounded;

    ///CHARACTER CONTROLLER
    [SerializeField, Self] private CharacterController controller;

    ///AUDIO CONTROLLER
    [SerializeField] private AudioController audioController;

    private float camXRotation;
    private Vector3 velocity;

    private void OnValidate()
    {
        this.ValidateRefs();
    }

    private void Awake()
    {
        if (audioController == null)
        {
            audioController = FindFirstObjectByType<AudioController>();
        }
    }

    private void Start()
    {
        ///INPUTS
        move = InputSystem.actions.FindAction("Player/Move");
        look = InputSystem.actions.FindAction("Player/Look");
        jump = InputSystem.actions.FindAction("Player/Jump");

        ///JUMP
        jump.started += Jump;
        jumping = new Vector3 (0.0f, 2.0f, 0.0f);


#if !UNITY_ANDROID
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
    }

    private void OnDisable()
    {

        ///JUMP
        jump.started -= Jump;

    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (controller.isGrounded)
        {
            audioController.PlayJumpSFX();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        Vector2 readMove = move.ReadValue<Vector2>();
        Vector2 readLook = look.ReadValue<Vector2>(); // (0.0)


        //controller.Move(movement * maxSpeed * Time.deltaTime);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 horizontal = (transform.right * readMove.x + transform.forward * readMove.y) * maxSpeed;

        Vector3 movement = horizontal + velocity;

        controller.Move(movement * Time.deltaTime);

#if UNITY_ANDROID
        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * mobileScale * Time.deltaTime);  
        camXRotation += mouseSensY * readLook.y * Time.deltaTime * rotationSpeed * -1;

#else
        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);  
        camXRotation += mouseSensY * readLook.y * Time.deltaTime * -1;
#endif       
        camXRotation = Mathf.Clamp(camXRotation, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(camXRotation, 0, 0);
    }

    ///MOUSE SENSITIVITY -----------------------------------------------------------
    public void ChangeMouseSensibility(float value)
    {
        Debug.Log($"Playerinput Value changed - {value}");

        mouseSensY = value;
        rotationSpeed = value;
    }
}
