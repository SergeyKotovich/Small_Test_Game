using UnityEngine;
using UnityEngine.Events;

public class EndButton : GameButton
{
    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private UnityEvent _endButtonPressed;

    
    public override void AnimationButton()
    {
        if (_gameTimer.IsRunning)
        {
            base.AnimationButton();
            _gameTimer.StopTimer();
            _endButtonPressed?.Invoke();
        }
    }
}