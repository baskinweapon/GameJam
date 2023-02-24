using UnityEngine;

[CreateAssetMenu(fileName = "Personality", menuName = "ScriptableObject/ new Personality")]
public class Personality : UnityEngine.ScriptableObject
{
    [SerializeField] private float _speedMove;
    [SerializeField] private string _welcomeMessage;
    [TextArea(4, 10)][SerializeField] private string _story;
    [TextArea(3, 10)][SerializeField] private string[] _communication;

    public float SpeedMove => _speedMove;
    public string WelcomeMessage => _welcomeMessage;
    public string Story => _story;
    public string[] Communication => _communication;
}
