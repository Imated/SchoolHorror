using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputActions _player;
    private Vector2 _movementVector;
    private bool _isJumping;
    private bool _isInteracting;

    private void OnEnable()
    {
        if (_player == null)
            _player = new InputActions();
        _player.Enable();
        _player.Player.Movement.performed += ctx => _movementVector = ctx.ReadValue<Vector2>();
        _player.Player.Movement.canceled += ctx => _movementVector = ctx.ReadValue<Vector2>();
        _player.Player.Jump.performed += ctx => _isJumping = true;
        _player.Player.Jump.canceled += ctx => _isJumping = false;        
        _player.Player.Interact.performed += ctx => _isInteracting = true;
        _player.Player.Interact.canceled += ctx => _isInteracting = false;
    }

    private void OnDisable()
    {
        _player.Player.Movement.performed -= ctx => _movementVector = ctx.ReadValue<Vector2>();
        _player.Player.Movement.canceled -= ctx => _movementVector = ctx.ReadValue<Vector2>();
        _player.Player.Jump.performed -= ctx => _isJumping = true;
        _player.Player.Jump.canceled -= ctx => _isJumping = false;        
        _player.Player.Interact.performed -= ctx => _isInteracting = true;
        _player.Player.Interact.canceled -= ctx => _isInteracting = false;
        _player.Disable();
    }

    public Vector2 GetMovementVector()
    {
        return _movementVector;
    }

    public bool IsJumping()
    {
        return _isJumping;
    }

    public bool IsInteracting()
    {
        return _isInteracting;
    }
}
