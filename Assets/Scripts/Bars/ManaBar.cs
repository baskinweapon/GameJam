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
        text.text = (int)Main.instance.playerInfo.currentMP + " / " + (int)Main.instance.playerInfo.maxMP;
        image.fillAmount = Main.instance.playerInfo.currentMP / Main.instance.playerInfo.maxMP;
    }
}
