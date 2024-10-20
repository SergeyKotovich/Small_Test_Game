using System;

public interface ITimeObserver
{
    public event Action<float> TimeChanged;
}