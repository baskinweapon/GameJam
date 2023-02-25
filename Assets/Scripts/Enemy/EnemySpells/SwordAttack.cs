using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : EnemySpellBase {
    public GameObject prefab;
    
    public override void StartAttack() {
        var pr = Instantiate(prefab, transform);
    }
}
