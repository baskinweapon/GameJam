using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellUI : MonoBehaviour {
   public Image[] panelsImages;
   public Color noManaColor;
   public Color noLevelColor;

   private int counter;

   public void Start() {
      foreach (var images in panelsImages) {
         images.color = new Color(1, 1, 1, 1);
         images.sprite = SpellSystem.instance.currentSpells[counter].icon;
         images.color = CheckSpell(images);
         counter++;
      }
   }
   
   
   public Color CheckSpell(Image _image) {
      var color = Color.white;
      for (int i = 0; i < panelsImages.Length; i++) {
         if (Main.instance.playerMP < SpellSystem.instance.currentSpells[i].manaCost) {
            color = noManaColor;
         }
         
         if (Main.instance.level < SpellSystem.instance.currentSpells[i].manaCost) {
            
         }
      }

      return color;
   }
   
   public void  ChangeOrSetSpell() {
      panelsImages[counter].sprite = SpellSystem.instance.spells[counter].icon;
   }
}
