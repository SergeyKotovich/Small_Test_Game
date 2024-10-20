using MessagePipe;
using VContainer;

public class StartButton : GameButton
{
    private IPublisher<TimerStarted> _timerStartedPublisher;

    [Inject]
    public void Construct(IPublisher<TimerStarted> timerStartedPublisher)
    {
        _timerStartedPublisher = timerStartedPublisher;
    }

    public override void OnClick()
    {
        base.OnClick();
        _timerStartedPublisher.Publish(new TimerStarted());
    }
}