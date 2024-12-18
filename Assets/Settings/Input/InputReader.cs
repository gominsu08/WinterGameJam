using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static KeyAction;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerInputActions
{
    public event Action<Vector2> OnMove;
    public event Action OnAttackEvent;
    public event Action OnEndAttackEvent;

    private KeyAction _playerInput;

    public Vector2 InputVector;

    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = new KeyAction();
            _playerInput.PlayerInput.SetCallbacks(this);
        }
        _playerInput.PlayerInput.Enable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        InputVector = context.ReadValue<Vector2>();
        OnMove?.Invoke(InputVector);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        OnAttackEvent?.Invoke();
        if (context.canceled)
            OnEndAttackEvent?.Invoke();

    }

    private void OnDisable()
    {
        _playerInput.PlayerInput.Disable();
    }
}
