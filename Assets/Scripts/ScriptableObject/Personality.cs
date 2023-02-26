using UnityEngine;

[CreateAssetMenu(fileName = "Personality", menuName = "ScriptableObject/ new Personality")]
public class Personality : UnityEngine.ScriptableObject
{
    [SerializeField] private float _speedMove;
    [SerializeField] private string _welcomeMessage;
    [TextArea(4, 10)][SerializeField] private string _story;
    [SerializeField] private MessageCommunication[] _communication;

    public float SpeedMove => _speedMove;
    public string WelcomeMessage => _welcomeMessage;
    public string Story => _story;
    public MessageCommunication[] Communication => _communication;
}

[System.Serializable]
public class MessageCommunication
{
    public string name;
    public Sprite sprite;
    [TextArea(4, 10)] public string messageVarOne;
    [TextArea(4, 10)] public string messageVarTwo;

    public string bottonOne;
    public string bottonTwo;
}