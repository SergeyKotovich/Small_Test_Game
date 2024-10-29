using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameTimer _timer;


    public void Awake()
    {
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