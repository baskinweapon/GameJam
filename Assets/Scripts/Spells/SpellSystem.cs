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
    public float cooldown;
    public float damage;
    public float manaCost;
}

public class SpellSystem : Singleton<SpellSystem> {
    public Action OnCooldown;
    public Action OnReady;
    public Action OnNoNeedMana;

    public Spell[] currentSpells = new Spell[4];

    public Spell lastSpellUse;
    
    public Spell[] spells;
    public bool isCasting;
    
    public void OnEnable() {
        InputSystem.OnCastFirstAbility += CastAbility;
        InputSystem.OnCastSecondAbility += CastAbility;
        InputSystem.OnCastThirdAbility += CastAbility;
        InputSystem.OnCastFourAbility += CastAbility;

       SetCurrentSpells();
    }

    public void SetCurrentSpells() {
         for (int i = 0; i < currentSpells.Length; i++) {
                    currentSpells[i] = spells[i];
         }
    }

    public void CastAbility(int _state) {
        if (_state == 1) {
            lastSpellUse = spells[_state];
        } else if (_state == 2) {
            lastSpellUse = spells[_state];
        } else if (_state == 3) {
            lastSpellUse = spells[_state];
        } else if (_state == 4){
            lastSpellUse = spells[_state];
        }

        StartCoroutine(Casting());
    }
    
    IEnumerator Casting() {
        isCasting = true;
        yield return new WaitForSeconds(lastSpellUse.cooldown);
        isCasting = false;
    }
}
