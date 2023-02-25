using General;
using UnityEngine;
using UnityEngine.UI;

public class SwapPanel : MonoBehaviour {
   public Image newSpellImage;
   public Image[] currentImages;
   public Spell spell;
   
   public void Swap(Spell _spell) {
      spell = _spell;
      if (spell.icon)
         newSpellImage.sprite = spell.icon;
      for (int i = 0; i < currentImages.Length; i++) {
         currentImages[i].sprite = Main.instance.playerInfo.CurrentSpells[i].icon;
      }
   }
   
   public int id;
   public void Set(int _id) {
      id = _id;
      Main.instance.ChangeCurrentSpell(_id, spell);
      CanvasMain.instance.CloseSwapPanel();
   }
   
   
}
