using DG.Tweening;
using UnityEngine;

public abstract class GameButton : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _endValue = 0.02f;
    private float _duration = 1;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public virtual void OnClick()
    {
        transform.DOLocalMoveX(_endValue, _duration).OnComplete(() => transform.DOMove(_startPosition, _duration));
    }
}