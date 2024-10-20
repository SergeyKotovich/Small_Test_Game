using System;
using MessagePipe;
using UnityEngine;
using VContainer;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _doorSound;

    private IDisposable _subscriptions;

    [Inject]
    public void Construct(ISubscriber<TimerStarted> timerStartedSubscriber,
        ISubscriber<TimerStopped> timerStoppedSubscriber)
    {
        _subscriptions = DisposableBag.Create(timerStartedSubscriber.Subscribe(_ => EnableBackgroundMusic()),
            timerStoppedSubscriber.Subscribe(_ => DisableBackgroundMusic()));
    }

    public void PlaySoundDoor()
    {
        _audioSource.clip = _doorSound;
        _audioSource.Play();
    }

    private void EnableBackgroundMusic()
    {
        _audioSource.clip = _backgroundMusic;
        _audioSource.Play();
    }

    private void DisableBackgroundMusic()
    {
        _audioSource.clip = null;
    }

    private void OnDestroy()
    {
        _subscriptions.Dispose();
    }
}