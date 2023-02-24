using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpellSystem : Singleton<SpellSystem> {
    public Action<int> OnCooldown;
    public Action<int> OnReady;
    public Action<int> OnNoNeedMana;
    public Action<int> OnCast;
    
    public Spell lastSpellUse;
    
    public bool isCasting;

    public void OnEnable() {
        InputSystem.OnCastFirstAbility += CastAbility;
        InputSystem.OnCastSecondAbility += CastAbility;
        InputSystem.OnCastThirdAbility += CastAbility;
        InputSystem.OnCastFourAbility += CastAbility;
    }
    
    public void CastAbility(int _state) {
        lastSpellUse = Main.instance.playerInfo.CurrentSpells[_state];
        
        StartCoroutine(Casting());
    }
    
    IEnumerator Casting() {
        isCasting = true;
        yield return new WaitForSeconds(lastSpellUse.cooldown);
        isCasting = false;
    }
    
    public void OnDisable() {
        InputSystem.OnCastFirstAbility -= CastAbility;
        InputSystem.OnCastSecondAbility -= CastAbility;
        InputSystem.OnCastThirdAbility -= CastAbility;
        InputSystem.OnCastFourAbility -= CastAbility;
    }
}
