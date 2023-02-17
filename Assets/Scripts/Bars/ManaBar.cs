using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;

    public void Update() {
        ChangeHealth();
    }

    public void ChangeHealth() {
        text.text = (int)Main.instance.playerMP + " / " + (int)Main.instance.maxMP;
        image.fillAmount = Main.instance.playerMP / Main.instance.maxMP;
    }
}
