using System;
using System.Collections;
using UnityEngine;

public abstract class CharacterAbstract : MonoBehaviour
{
    [SerializeField] private Personality _personality;
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _checkPointDelay;

    private Transform _transform;
    private int _targetPos;
    private bool _isMetHero;

    public Personality Personality => _personality;
    public Transform Transform => _transform;
    public Transform[] MovePoints => _movePoints;
    public bool IsMetHero => _isMetHero;

    public int TargetPos
    {
        get => _targetPos;
        set
        {
            if (value < _movePoints.Length) _targetPos = value;
            else throw new Exception("out index aray movePointsCharacter");
        }
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        if (_movePoints.Length >= 2) StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        _targetPos = 0;

        while (_targetPos < _movePoints.Length - 1 && !IsMetHero)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _movePoints[_targetPos].position, _personality.SpeedMove * Time.deltaTime);
            if (_transform.position == _movePoints[_targetPos].position)
            {
                _targetPos++;
                yield return new WaitForSeconds(_checkPointDelay);
            }
            else yield return null;
        }

        while (_targetPos > 0 && !IsMetHero)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _movePoints[_targetPos].position, _personality.SpeedMove * Time.deltaTime);
            if (_transform.position == _movePoints[_targetPos].position)
            {
                _targetPos--;
                yield return new WaitForSeconds(_checkPointDelay);
            }
            else yield return null;
        }

        StartCoroutine(Move());
    }

}
