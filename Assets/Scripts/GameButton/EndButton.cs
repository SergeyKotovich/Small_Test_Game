using MessagePipe;
using VContainer;

public class EndButton : GameButton
{
    private IPublisher<TimerStopped> _timerStoppedPublisher;

    [Inject]
    public void Construct(IPublisher<TimerStopped> timerStoppedPublisher)
    {
        _timerStoppedPublisher = timerStoppedPublisher;
    }

    public override void OnClick()
    {
        base.OnClick();
        _timerStoppedPublisher.Publish(new TimerStopped());
    }
}