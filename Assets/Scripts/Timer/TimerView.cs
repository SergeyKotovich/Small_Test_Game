using TMPro;
using UnityEngine;
using VContainer;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    private ITimeObserver _timer;

    [Inject]
    public void Construct(ITimeObserver timer)
    {
        _timer = timer;
        _timer.TimeChanged += UpdateTime;
    }
    
    private void UpdateTime(float time)
    {
        _timerText.text = time.ToString("F");
    }

    private void OnDestroy()
    {
        _timer.TimeChanged -= UpdateTime;
    }
}