using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;

public class FoundNote : MonoBehaviour
{
    [TextArea(4, 15)][SerializeField] private string _note;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanvasMain.instance.OpenNotePanel(_note);
        }
    }

}
