using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {
   public TextMeshProUGUI text;
   public Image image;
   public int count;

   public Spell spell;
   private bool needLevel;
   
   private void Start() {
      image.fillAmount = 0;
      Main.OnChangeSpell += ChangeSpell;
      SetSpell(Main.instance.playerInfo.CurrentSpells[count]);
   }

   private void ChangeSpell() {
      spell = Main.instance.playerInfo.CurrentSpells[count];
   }

   public void SetSpell(Spell _spell) {
      spell = _spell;
   }

   private bool isCasting;
   public void PressSpell() {
      //if (needLevel) return;
      if (isCasting) return;
      if (Main.instance.playerInfo.currentMP < spell.manaCost) return;
      
      CastAbility();
      StartCoroutine(StartCooldown());
   }


   public void CastAbility() {
      var pref = Instantiate(spell.prefab);
      Main.instance.ChangeMP(spell.manaCost);
      switch (spell.type) {
         case SpellType.areaDamage:
            pref.transform.position = Camera.main.ScreenToWorldPoint(InputSystem.instance.GetMousePosition());
            pref.transform.position = new Vector3(pref.transform.position.x, pref.transform.position.y, 0);
            break;
         case SpellType.onPlayer:
            pref.transform.parent = Main.instance.character.transform;
            pref.transform.localPosition = Vector3.zero;
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }
   }
   
   private float time;
   IEnumerator StartCooldown() {
      isCasting = true;
      
      while (time <= spell.cooldown) {
         time += Time.deltaTime;
         image.fillAmount = (spell.cooldown - time) /
                            spell.cooldown;
         text.text = ((int)(spell.cooldown - time)).ToString();
         yield return null;
      }

      text.text = "";
      time = 0;
      isCasting = false;
   }

   private void OnDisable() {
      Main.OnChangeSpell -= ChangeSpell;
   }
}
