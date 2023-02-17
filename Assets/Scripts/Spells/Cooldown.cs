using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {
   public TextMeshProUGUI text;
   public Image image;
   public int count;

   public Spell spell;
   private bool needLevel;
   private void Start() {
      /*if (count > Main.instance.level) {
         needLevel = true;
      } else {
         image.fillAmount = 0;
      }*/
      image.fillAmount = 0;
      SetSpell(SpellSystem.instance.currentSpells[count]);
   }

   public void SetSpell(Spell _spell) {
      spell = _spell;
   }

   private bool isCasting;
   public void PressSpell() {
      //if (needLevel) return;
      if (isCasting) return;
      if (Main.instance.playerMP < spell.manaCost) return;
      
      CastAbility();
      StartCoroutine(StartCooldown());
   }


   public void CastAbility() {
      var pref = Instantiate(spell.prefab);
      pref.transform.position = Camera.main.ScreenToWorldPoint(InputSystem.instance.GetMousePosition());
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
}
