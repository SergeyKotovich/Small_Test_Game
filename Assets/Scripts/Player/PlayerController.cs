using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private RotationController _rotationController;
    
    private CharacterController _characterController;
    private PlayerInputActions _playerInputActions;

    [Inject]
    public void Construct()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInputActions = new PlayerInputActions();
        _movementController.Initialize(_characterController,_playerInputActions);
        _rotationController.Initialize(_playerInputActions);
    }
}