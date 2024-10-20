using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _boost = 2f;
    [SerializeField] private float _power = 10;
    [SerializeField] private float _gravity = -9.81f;

    private float _verticalVelocity;
    private bool _isSprinting;

    private CharacterController _characterController;
    private PlayerInputActions _playerInputActions;

    public void Initialize(PlayerInputActions playerInputActions)
    {
        _playerInputActions = playerInputActions;
        _characterController = GetComponent<CharacterController>();

        _playerInputActions.Player.Sprint.started += OnSprintStarted;
        _playerInputActions.Player.Sprint.canceled += OnSprintCanceled;
        _playerInputActions.Player.Jump.performed += OnJump;
    }

    private void OnSprintStarted(InputAction.CallbackContext callbackContext)
    {
        _isSprinting = true;
    }

    private void OnSprintCanceled(InputAction.CallbackContext callbackContext)
    {
        _isSprinting = false;
    }

    private void Update()
    {
        Move();
        HandleGravity();
    }

    private void HandleGravity()
    {
        if (!_characterController.isGrounded)
        {
            _verticalVelocity += _gravity * Time.deltaTime;
        }
        else if (_verticalVelocity < 0)
        {
            _verticalVelocity = 0;
        }
    }

    private void Move()
    {
        var inputValue = _playerInputActions.Player.Move.ReadValue<Vector2>();

        var direction = new Vector3(inputValue.x, 0, inputValue.y);
        direction = transform.TransformDirection(direction);

        if (_isSprinting)
        {
            _characterController.Move(
                (direction * _speed * _boost + new Vector3(0, _verticalVelocity)) * Time.deltaTime);
        }
        else
        {
            _characterController.Move((direction * _speed + new Vector3(0, _verticalVelocity)) * Time.deltaTime);
        }
    }

    private void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = _power;
        }
    }


    private void OnDisable()
    {
        _playerInputActions.Player.Sprint.started -= OnSprintStarted;
        _playerInputActions.Player.Sprint.canceled -= OnSprintCanceled;
        _playerInputActions.Player.Jump.performed -= OnJump;
    }
}