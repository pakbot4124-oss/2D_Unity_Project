using System;
using UnityEngine;

public class InputReader : MonoBehaviour, PlayerInput.IPlayerMovementActions
{
    public Vector2 MovementDirection { get; private set; }
    public bool IsAttack { get; set; }

    public event Action JumpEvent;
    public event Action RollEvent;

    PlayerInput inputs;

    void Start()
    {
        inputs = new PlayerInput();
        inputs.PlayerMovement.SetCallbacks(this);
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        MovementDirection = context.ReadValue<Vector2>();
        // Debug.Log(MovementDirection);
    }

    public void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpEvent?.Invoke();
        }
    }

    public void OnAttacks(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsAttack = true;
            Debug.Log("Attacks");
        }
    }

    public void OnRoll(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Roll");
            RollEvent?.Invoke();
        }
    }
}
