using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image image;
    public TextMeshProUGUI text;

    public void Update() {
        ChangeHealth();
    }

    public void ChangeHealth() {
        text.text = (int)Main.instance.playerInfo.currentHP + " / " + (int)Main.instance.playerInfo.maxHp;
        image.fillAmount = Main.instance.playerInfo.currentHP / Main.instance.playerInfo.maxHp;
    }
}
