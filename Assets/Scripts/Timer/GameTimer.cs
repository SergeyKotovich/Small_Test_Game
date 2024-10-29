using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public event Action<float> TimeChanged;
    public event Action<float, int> TimerStopped;
    public bool IsRunning { get; private set; }
    
    [SerializeField] private int _delay = 10;
    [SerializeField] private float _step = 0.01f;

    private float _currentTime;
    
    private int _timerStartCount;
    
    public async void StartTimer()
    {
        IsRunning = true;

        while (IsRunning)
        {
            await UniTask.Delay(_delay);
            if (!IsRunning)
            {
                return;
            }

            _currentTime += _step;
            TimeChanged?.Invoke(_currentTime);
        }
    }


    public void StopTimer()
    {
        IsRunning = false;
        TimerStopped?.Invoke(_currentTime, _timerStartCount);
        _timerStartCount++;
        _currentTime = 0;
        TimeChanged?.Invoke(_currentTime);
    }
}