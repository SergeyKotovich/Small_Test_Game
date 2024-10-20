using MessagePipe;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonHandler : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    public void Initialize(PlayerInputActions playerInputActions)
    {
        _playerInputActions = playerInputActions;
        _playerInputActions.Player.Fire.performed += OnClick;
    }

    private void OnClick(InputAction.CallbackContext callbackContext)
    {
        var gameButton = RaycastUtils.GetSelectedObject<GameButton>();
        if (gameButton != null)
        {
            gameButton.OnClick();
        }
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Fire.performed -= OnClick;
    }
}