using MessagePipe;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonHandler : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    private SoundsManager _soundsManager;

    public void Initialize(PlayerInputActions playerInputActions, SoundsManager soundsManager)
    {
        _soundsManager = soundsManager;
        _playerInputActions = playerInputActions;
        _playerInputActions.Player.Fire.performed += OnClick;
    }

    private void OnClick(InputAction.CallbackContext callbackContext)
    {
        var gameButton = RaycastUtils.GetSelectedObject<GameButton>();
        if (gameButton != null)
        {
            gameButton.OnClick();
            _soundsManager.PlayButtonPressedSound();
        }
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Fire.performed -= OnClick;
    }
}