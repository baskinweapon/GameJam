using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Spell {
    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab;
}

public class SpellSystem : MonoBehaviour {
    public Spell[] spells;

    public void Start() {
        SetSpells();
    }

    public void SetSpells() {
        for (int i = 0; i < spells.Length; i++) {
            Instantiate(spells[i].prefab);
        }
    }
    
}
