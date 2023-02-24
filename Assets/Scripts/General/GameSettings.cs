using System;
using UnityEngine;

[Serializable]
public enum SpellType {
    areaDamage,
    onPlayer,
}

[Serializable]
public class Spell {
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public float manaCost;
    public AudioClip audioClip;
    public float damage;
    public float cooldown;
    public SpellType type;
}

[Serializable]
public class PlayerInfo {
    public float currentHP;
    public float maxHp;
    public float currentMP;
    public float maxMP;

    public int level;

    public Spell[] CurrentSpells;
}

namespace General {

    [Serializable]
    public struct GameSettings {

        public bool isStartGame;
        public int currentSceneId;

        public PlayerInfo player;
        
        public int currentSpellId;
        public Spell[] spells;
        
    }
}