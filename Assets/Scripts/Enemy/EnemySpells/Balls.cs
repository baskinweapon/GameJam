using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Balls : EnemySpellBase {
    public GameObject ballPref;

    public float lifeTime = 3;
    public float speed;
    
    public override void StartAttack() {
        var ball = Instantiate(ballPref);
        ball.transform.position = transform.position;

        StartCoroutine(AttackProcess(ball));
    }

    private float time;
    IEnumerator AttackProcess(GameObject ball) {
        time = lifeTime;
        Vector3 pos = Main.instance.character.transform.position;
        while (time >= 0) {
            time -= Time.deltaTime;
            if (ball) {
                var dir = pos - ball.transform.position;
                ball.transform.position += speed * Time.deltaTime * dir.normalized;
            }
            yield return null;
        }
        Destroy(ball.gameObject);
    }
    
}
