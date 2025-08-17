using System;
using UnityEngine.InputSystem;

public class InputManager
{
    // Input action asset reference
    private PlayerControls playerControls;

    // Property to get the movement input value
    public float Movement => playerControls.Player.Move.ReadValue<float>();

    // Event to notify when the jump action is performed
    public event Action OnJump;
    public event Action<bool> OnRun;

    // Constructor to initialize the input manager and enable player controls
    public InputManager()
    {
        playerControls = new PlayerControls();
        // Enable the player controls
        playerControls.Player.Enable();

        // Subscribe to the jump action performed event
        playerControls.Player.Jump.performed += OnJumpPerformed;

        playerControls.Player.Run.performed += OnRunPerformed;
        playerControls.Player.Run.canceled += OnRunCanceled;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private void OnRunPerformed(InputAction.CallbackContext context)
    {
        OnRun?.Invoke(true);
    }

    private void OnRunCanceled(InputAction.CallbackContext context)
    {
        OnRun?.Invoke(false);
    }
}