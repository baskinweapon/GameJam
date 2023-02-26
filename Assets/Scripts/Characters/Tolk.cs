using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;
using UnityEngine.UI;

public class Tolk : Singleton<Tolk>
{
    [SerializeField] private Text _name;
    [SerializeField] private GameObject _avatar;
    [Space]
    [SerializeField] private Text _printText;
    [Space]
    [SerializeField] private Button _buttonOne;
    [SerializeField] private Text _buttonOneText;
    [Space]
    [SerializeField] private Button _buttonTwo;
    [SerializeField] private Text _buttonTwoText;

    private MessageCommunication[] _communication;
    private Image _sprite;
    private int _currentMessage;

    private void Start()
    {
        _currentMessage = 0;
        if (_sprite) _sprite = _avatar.GetComponent<Image>();
    }

    public void SendSrartMessage(MessageCommunication[] communication)
    {
        _communication = communication;

        if (_communication[_currentMessage].bottonTwo == null) _buttonTwo.gameObject.SetActive(false);

        _name.text = _communication[_currentMessage].name;
        if (_sprite) _sprite.sprite = _communication[_currentMessage].sprite;
        _printText.text = _communication[_currentMessage].messageVarOne;
        _buttonOneText.text = _communication[_currentMessage].bottonOne;
        if (_communication[_currentMessage].bottonTwo != null) _buttonTwoText.text = _communication[_currentMessage].bottonTwo;
    }

    public void DisplayOneMessage()
    {
        _currentMessage++;

        if (_currentMessage >= _communication.Length) {
            CanvasMain.instance.CloseAllWindow();
            return;
        }

        if (_communication[_currentMessage].bottonTwo == null) _buttonTwo.gameObject.SetActive(false);

        _name.text = _communication[_currentMessage].name;
        if (_sprite) _sprite.sprite = _communication[_currentMessage].sprite;
        _printText.text = _communication[_currentMessage].messageVarOne;
        _buttonOneText.text = _communication[_currentMessage].bottonOne;
        if (_communication[_currentMessage].bottonTwo != null) _buttonTwoText.text = _communication[_currentMessage].bottonTwo;
    }

    public void DisplayTwoMessage()
    {
        _currentMessage++;

        if (_currentMessage >= _communication.Length) {
            CanvasMain.instance.CloseAllWindow();
            return;
        }

        if (_communication[_currentMessage].bottonTwo == null) _buttonTwo.gameObject.SetActive(false);

        _name.text = _communication[_currentMessage].name;
        if (_sprite) _sprite.sprite = _communication[_currentMessage].sprite;
        _printText.text = _communication[_currentMessage].messageVarTwo;
        _buttonOneText.text = _communication[_currentMessage].bottonOne;
        if (_communication[_currentMessage].bottonTwo != null) _buttonTwoText.text = _communication[_currentMessage].bottonTwo;
    }
}
