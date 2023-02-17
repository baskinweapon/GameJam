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
        text.text = (int)Main.instance.playerHP + " / " + (int)Main.instance.maxHP;
        image.fillAmount = Main.instance.playerHP / Main.instance.maxHP;
    }
}
