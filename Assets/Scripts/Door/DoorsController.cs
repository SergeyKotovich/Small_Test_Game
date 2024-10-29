using Cysharp.Threading.Tasks;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class DoorsController : MonoBehaviour
{
    [SerializeField] private Transform _firstDoor;
    [SerializeField] private Transform _secondDoor;
    [SerializeField] private int _delay = 2000;

    private readonly float _startValue = -1.2f;
    private readonly float _endValue = -5f;
    private readonly float _duration = 1f;
    
    [UsedImplicitly]
    public async void OpenDoors()
    {
        _firstDoor.DOLocalMoveY(_endValue, _duration);
        _secondDoor.DOLocalMoveY(_endValue, _duration);
        
        await UniTask.Delay(_delay);

        _firstDoor.DOLocalMoveY(_startValue, _duration);
        _secondDoor.DOLocalMoveY(_startValue, _duration);
    }

}