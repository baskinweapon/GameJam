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
    [SerializeField] private GameObject _storyPanel;
    [SerializeField] private Text _story;
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
        _sprite = _avatar.GetComponent<Image>();
    }

    public void SendSrartMessage(MessageCommunication[] communication, string story)
    {
        _communication = communication;

        _currentMessage = 0;
        _storyPanel.gameObject.SetActive(false);

        if (story != "")
        {
            _storyPanel.gameObject.SetActive(true);
            _story.text = story;
        }

        if (_communication[_currentMessage].bottonTwo == "") _buttonTwo.gameObject.SetActive(false);

        _name.text = _communication[_currentMessage].name;
        if (_communication[_currentMessage].sprite) _sprite.sprite = _communication[_currentMessage].sprite;
        _printText.text = _communication[_currentMessage].messageVarOne;
        _buttonOneText.text = _communication[_currentMessage].bottonOne;
        if (_communication[_currentMessage].bottonTwo != "") _buttonTwoText.text = _communication[_currentMessage].bottonTwo;
    }

    public void DisplayOneMessage()
    {
        _currentMessage++;

        if (_currentMessage >= _communication.Length) {
            CanvasMain.instance.CloseAllWindow();
            return;
        }

        _buttonOne.gameObject.SetActive(true);
        _buttonTwo.gameObject.SetActive(true);

        if (_communication[_currentMessage].bottonTwo == "") _buttonTwo.gameObject.SetActive(false);

        _name.text = _communication[_currentMessage].name;
        if (_communication[_currentMessage].sprite) _sprite.sprite = _communication[_currentMessage].sprite;
        _printText.text = _communication[_currentMessage].messageVarOne;
        _buttonOneText.text = _communication[_currentMessage].bottonOne;
        if (_communication[_currentMessage].bottonTwo != "") _buttonTwoText.text = _communication[_currentMessage].bottonTwo;
    }

    public void DisplayTwoMessage()
    {
        _currentMessage++;

        if (_currentMessage >= _communication.Length) {
            CanvasMain.instance.CloseAllWindow();
            return;
        }

        _buttonOne.gameObject.SetActive(true);
        _buttonTwo.gameObject.SetActive(true);

        if (_communication[_currentMessage].bottonTwo == "") _buttonTwo.gameObject.SetActive(false);

        _name.text = _communication[_currentMessage].name;
        if (_communication[_currentMessage].sprite) _sprite.sprite = _communication[_currentMessage].sprite;
        _printText.text = _communication[_currentMessage].messageVarTwo;
        _buttonOneText.text = _communication[_currentMessage].bottonOne;
        if (_communication[_currentMessage].bottonTwo != "") _buttonTwoText.text = _communication[_currentMessage].bottonTwo;
    }
}
