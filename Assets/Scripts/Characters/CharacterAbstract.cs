using System;
using System.Collections;
using General;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterAbstract : MonoBehaviour
{
    [SerializeField] private Personality _personality;
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _checkPointDelay;
    [Space]
    [SerializeField] private float _distanceForTolk;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Text _welcomeMessage;

    private Transform _transform;
    private GameObject _player;
    private Transform _playerTransform;
    private int _targetPos;
    private bool _isMetHero;
    private bool _isWelcomeMessageComplete;
    private bool _isCommunicationComplete;

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

        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null) _playerTransform = _player.GetComponent<Transform>();

    }

    private void Update()
    {
        if (_personality.WelcomeMessage != null && !_isWelcomeMessageComplete)
        {
            if (!_canvas.gameObject.activeInHierarchy && _player != null)
            {
                float distanceToPlayer = Vector2.Distance(_transform.position, _playerTransform.position);
                if (distanceToPlayer <= _distanceForTolk) ShowWelcomeMessage();
            }
            else if (_canvas.gameObject.activeInHierarchy)
            {
                float distanceToPlayer = Vector2.Distance(_transform.position, _playerTransform.position);
                if (distanceToPlayer > _distanceForTolk) HideWelcomeMessage();
            }
        }
    }

    private void ShowWelcomeMessage()
    {
        _welcomeMessage.text = _personality.WelcomeMessage;
        _canvas.gameObject.SetActive(true);
    }

    private void HideWelcomeMessage()
    {
        _welcomeMessage.text = "";
        _canvas.gameObject.SetActive(false);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isWelcomeMessageComplete = true;
            StopAllCoroutines();
            if (_personality.WelcomeMessage != null) HideWelcomeMessage();
            if (!_isCommunicationComplete && _personality.Communication != null)
            {
                _isCommunicationComplete = true;
                InputSystem.instance.Pause();
                CanvasMain.instance.OpenTolkPanel(_personality.Communication, _personality.Story);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_movePoints.Length >= 2) StartCoroutine(Move());
        }
    }
}
