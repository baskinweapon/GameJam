using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;
using UnityEngine.UI;

public class Note : Singleton<Note>
{
    [SerializeField] private Text _text;

    public void SetText(string text)
    {
        _text.text = text;
    }
}
