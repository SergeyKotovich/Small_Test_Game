using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeTimeScope : LifetimeScope
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameTimer _gameTimer;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_playerController);
        builder.RegisterInstance(_gameTimer).AsSelf().AsImplementedInterfaces();
        
        RegisterMessagePipe(builder);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        var options = builder.RegisterMessagePipe();
        builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
        
        builder.RegisterMessageBroker<TimerStarted>(options);
        builder.RegisterMessageBroker<TimerStopped>(options);
    }
}
