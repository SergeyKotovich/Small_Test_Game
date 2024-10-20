using System;

public interface ITimerStoppable
{
    public event Action<float, int> TimerStopped; 
}