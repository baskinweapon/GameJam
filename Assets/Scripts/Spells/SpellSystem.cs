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

public class SpellSystem : Singleton<SpellSystem> {
    public Spell[] spells;
}
