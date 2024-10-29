using UnityEngine;
using UnityEngine.Events;

public class StartButton : GameButton
{
    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private UnityEvent _startButtonPressed;
    
    public override void AnimationButton()
    {
        if (_gameTimer.IsRunning)
        {
            return;
        }
        base.AnimationButton();
        _gameTimer.StartTimer();
        _startButtonPressed?.Invoke();
    }
}