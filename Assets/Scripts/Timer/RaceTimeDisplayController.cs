using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceTimeDisplayController : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _results;
    [SerializeField] private GameTimer _timer;


    public void Awake()
    {
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