using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private CharacterController _characterController;
    private PlayerInputActions _playerInputActions;
    
    public void Initialize(CharacterController characterController, PlayerInputActions playerInputActions)
    {
        _playerInputActions = playerInputActions;
        _characterController = characterController;
    }
    private void OnEnable()
    {
        _playerInputActions.Enable();
    }
    
    private void Update()
    {
        var inputValue = _playerInputActions.Player.Move.ReadValue<Vector2>();
        
        var direction = new Vector3(inputValue.x, 0, inputValue.y);
        
        direction = transform.TransformDirection(direction);
        
        _characterController.SimpleMove(direction * _speed);
    }


    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

   
}