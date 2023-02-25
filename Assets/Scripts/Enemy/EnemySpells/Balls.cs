using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Balls : EnemySpellBase {
    public GameObject ballPref;

    public float lifeTime = 3;
    private List<GameObject> balls = new List<GameObject>();
    
    
    
    public override void StartAttack() {
        balls = new List<GameObject>();
        for (int i = 0; i < 10; i++) {
            var nb = Instantiate(ballPref);
            nb.transform.position = transform.position;
            balls.Add(nb);
        }

        StartCoroutine(AttackProcess());
    }

    private float time;
    IEnumerator AttackProcess() {
        time = lifeTime;
        int i = 0;
        while (time >= 0) {
            time -= Time.deltaTime;
            balls[i].transform.DOMove(Main.instance.character.transform.position, 2f);
            yield return new WaitForSeconds(0.3f);
        }
    }
    
    // Update is called once per frame
    void Update() {
        
    }
}
