using System;
using System.Collections;
using UnityEngine;

public class Heal : MonoBehaviour {
    public float value;

    public void Start() {
        StartCoroutine(Healing());
        Destroy(gameObject, 2f);
    }

    public IEnumerator Healing() {
        var res = Mathf.Clamp(Main.instance.playerInfo.currentHP + value, 0, Main.instance.playerInfo.maxHp); 
        while (Math.Abs(Main.instance.playerInfo.currentHP - res) > 0.1f) {
            yield return new WaitForSeconds(0.1f);
            Main.instance.plusHP(0.1f);
        }
    }


    private void OnDestroy() {
        StopAllCoroutines();
    }
}
