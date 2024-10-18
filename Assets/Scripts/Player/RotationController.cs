using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private float _minY = -60;
    [SerializeField] private float _maxY = 60;
    [SerializeField] private float _sensitivityX = 1.0f; 
    [SerializeField] private float _sensitivityY = 1.0f; 

    private float _moveX;
    private float _moveY;

    private PlayerInputActions _playerInputActions;

    public void Initialize(PlayerInputActions playerInputActions)
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerInputActions = playerInputActions;
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void LateUpdate()
    {
        var lookInput = _playerInputActions.Player.Look.ReadValue<Vector2>();

        _moveX += lookInput.x * _sensitivityX;
        _moveY -= lookInput.y * _sensitivityY;
        
        _moveY = Mathf.Clamp(_moveY, _minY, _maxY);
        
        transform.rotation = Quaternion.Euler(_moveY, _moveX, 0);
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }
}