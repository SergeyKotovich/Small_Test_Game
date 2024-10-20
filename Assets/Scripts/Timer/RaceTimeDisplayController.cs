using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VContainer;

public class RaceTimeDisplayController : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _results;
    private ITimerStoppable _timer;

    [Inject]
    public void Construct(ITimerStoppable timer)
    {
        _timer = timer;
        _timer.TimerStopped += UpdateResult;
    }

    private void UpdateResult(float time, int index)
    {
        var safeIndex = index % _results.Count;
        _results[safeIndex].text = time.ToString("F");
    }

    private void OnDestroy()
    {
        _timer.TimerStopped -= UpdateResult;
    }
}