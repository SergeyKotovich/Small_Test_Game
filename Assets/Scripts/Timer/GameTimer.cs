using System;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;

public class GameTimer : MonoBehaviour, ITimeObserver, ITimerStoppable
{
    public event Action<float> TimeChanged;
    public event Action<float, int> TimerStopped;

    [SerializeField] private int _delay = 10;
    [SerializeField] private float _step = 0.01f;

    private float _currentTime;
    private bool _isRunning;
    private int _timerStartCount;

    private IDisposable _subscriptions;

    [Inject]
    public void Construct(ISubscriber<TimerStarted> timerStartedSubscriber,
        ISubscriber<TimerStopped> timerStoppedSubscriber)
    {
        _subscriptions = DisposableBag.Create(
            timerStartedSubscriber.Subscribe(_ => StartTimer()),
            timerStoppedSubscriber.Subscribe(_ => StopTimer())
        );
    }

    private async void StartTimer()
    {
        _isRunning = true;

        while (_isRunning)
        {
            await UniTask.Delay(_delay);
            if (!_isRunning)
            {
                return;
            }

            _currentTime += _step;
            TimeChanged?.Invoke(_currentTime);
        }
    }


    private void StopTimer()
    {
        _isRunning = false;
        TimerStopped?.Invoke(_currentTime, _timerStartCount);
        _timerStartCount++;
        _currentTime = 0;
        TimeChanged?.Invoke(_currentTime);
    }

    private void OnDestroy()
    {
        _subscriptions.Dispose();
    }
}