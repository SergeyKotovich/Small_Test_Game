using MessagePipe;
using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private RotationController _rotationController;
    [SerializeField] private ButtonHandler _buttonHandler;

    private PlayerInputActions _playerInputActions;

    [Inject]
    public void Construct()
    {
        _playerInputActions = new PlayerInputActions();
        _movementController.Initialize(_playerInputActions);
        _rotationController.Initialize(_playerInputActions);
        _buttonHandler.Initialize(_playerInputActions);
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDestroy()
    {
        _playerInputActions.Disable();
    }
}