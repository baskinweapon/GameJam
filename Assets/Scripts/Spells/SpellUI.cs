using System;
using UnityEngine;
using UnityEngine.UI;

public class SpellUI : MonoBehaviour {
   public Image[] panelsImages;
   public Color noManaColor;
   public Color noLevelColor;

   private int counter;

   public void Start() {
      SetImages();
      Main.OnChangeSpell += SetImages;
   }

   public void SetImages() {
      counter = 0;
      foreach (var images in panelsImages) {
         images.color = new Color(1, 1, 1, 1);
         images.sprite = Main.instance.playerInfo.CurrentSpells[counter].icon;
         images.color = CheckSpell(images);
         counter++;
      }
   }

   public Color CheckSpell(Image _image) {
      var color = Color.white;
      for (int i = 0; i < panelsImages.Length; i++) {
         if (Main.instance.playerInfo.currentMP < Main.instance.playerInfo.CurrentSpells[counter].manaCost) {
            color = noManaColor;
         }
      }

      return color;
   }
   
   private void OnDisable() {
      Main.OnChangeSpell += SetImages;
   }
}
