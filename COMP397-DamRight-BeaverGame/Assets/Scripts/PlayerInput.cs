using KBCore.Refs;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    ///INPUT ACTIONS -------------------
    private InputAction move;
    private InputAction look;
    private InputAction jump;

    
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -30.0f;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField] private float mouseSensY = 5.0f;
    [SerializeField, Child] private Camera cam;


    ///CHARACTER CONTROLLER
    [SerializeField, Self] private CharacterController controller;

    ///AUDIO CONTROLLER
    [SerializeField, Scene] private AudioController audioController;

    private float camXRotation;
    private Vector3 velocity;

    private void OnValidate()
    {
        this.ValidateRefs();
    }

    private void Start()
    {
        ///INPUTS
        move = InputSystem.actions.FindAction("Player/Move");
        look = InputSystem.actions.FindAction("Player/Look");
        jump = InputSystem.actions.FindAction("Player/Jump");

        ///JUMP
        jump.started += Jump;

        ///CURSOR
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {

        ///JUMP
        jump.started -= Jump;

    }

    private void Jump(InputAction.CallbackContext context)
    {
        ///JUMP SOUND EFFECT
        audioController.PlayJumpSFX();
    }

    void Update()
    {
        Vector2 readMove = move.ReadValue<Vector2>();
        Vector2 readLook = look.ReadValue<Vector2>(); // (0.0)

        ///PLAYER MOVEMENT
        Vector3 movement = transform.right * readMove.x + transform.forward * readMove.y;


        //controller.Move(movement * maxSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        movement *= maxSpeed * Time.deltaTime;
        movement += velocity;
        controller.Move(movement);

        ///PLAYER ROTATION
        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);

        ///ROTATE CAMERA
        camXRotation += mouseSensY * readLook.y * Time.deltaTime * -1;
        camXRotation = Mathf.Clamp(camXRotation, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(camXRotation * readLook.y, 0, 0);
    }

    ///MOUSE SENSITIVITY -----------------------------------------------------------
    public void ChangeMouseSensibility(float value)
    {
        Debug.Log($"Playerinput Value changed - {value}");

        mouseSensY = value;
        rotationSpeed = value;
    }


}
