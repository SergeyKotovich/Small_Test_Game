using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MessagePipe;
using UnityEngine;
using VContainer;

public class DoorsController : MonoBehaviour
{
    [SerializeField] private Transform _firstDoor;
    [SerializeField] private Transform _secondDoor;
    [SerializeField] private int _delay = 2000;

    private readonly float _startValue = -1.2f;
    private readonly float _endValue = -5f;
    private readonly float _duration = 1f;

    private IDisposable _subscriptions;
    private SoundsManager _soundsManager;

    [Inject]
    public void Construct(ISubscriber<TimerStarted> timerStartedSubscriber, SoundsManager soundsManager)
    {
        _soundsManager = soundsManager;
        _subscriptions = timerStartedSubscriber.Subscribe(_ => OpenDoors().Forget());
    }

    private async UniTask OpenDoors()
    {
        _firstDoor.DOLocalMoveY(_endValue, _duration);
        _secondDoor.DOLocalMoveY(_endValue, _duration);
        
        _soundsManager.PlaySoundDoor();
        
        await UniTask.Delay(_delay);
        
        _soundsManager.PlaySoundDoor();
        
        _firstDoor.DOLocalMoveY(_startValue, _duration);
        _secondDoor.DOLocalMoveY(_startValue, _duration);
    }

    private void OnDestroy()
    {
        _subscriptions.Dispose();
    }
}